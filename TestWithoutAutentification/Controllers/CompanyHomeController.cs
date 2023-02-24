using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestWithoutAutentification.Models;

namespace TestWithoutAutentification.Controllers
{
    public class CompanyHomeController : Controller
    {
        private readonly ILogger<CompanyHomeController> _logger;
        private readonly AppDbContext _context;

        public CompanyHomeController(AppDbContext context, ILogger<CompanyHomeController> logger)
        {
            _logger = logger;
            _context = context;
           
        }
        
        public async Task<IActionResult> Index(string searchString, int specialization, int city, int experience)
        {
            if(User.Identity.IsAuthenticated && User.IsInRole("company"))
            {
                 DeletePDFFiles();

                 var resumes = _context.Resume.Include(x => x.City)
                                        .Include(x => x.Sex)
                                        .Include(x => x.WorkExperience)
                                        .Include(x => x.Salary.Currency)
                                        .Include(x => x.EducationLevel)
                                        .Include(x => x.ForeignLanguage.Language)
                                        .Include(x => x.ForeignLanguage.LanguageLevel)
                                        .Include(x => x.User);

                ViewBag.Specializations = new SelectList(_context.Specialization, "Id", "Name");
                ViewBag.Cities = new SelectList(_context.City, "Id", "Name");
                ViewBag.Experiences = new SelectList(_context.WorkExperience, "Id", "Name");


                if (!String.IsNullOrEmpty(searchString))
                {
                    resumes = resumes.Where(s => s.Position!.Contains(searchString))
                        .Include(x => x.City)
                        .Include(x => x.Sex)
                        .Include(x => x.WorkExperience)
                        .Include(x => x.Salary.Currency)
                        .Include(x => x.EducationLevel)
                        .Include(x => x.ForeignLanguage.Language)
                        .Include(x => x.ForeignLanguage.LanguageLevel)
                        .Include(x => x.User);
                }

                if (specialization != 0)
                {
                    resumes = resumes.Where(s => s.SpecializationId == specialization)
                        .Include(x => x.City)
                        .Include(x => x.Sex)
                        .Include(x => x.WorkExperience)
                        .Include(x => x.Salary.Currency)
                        .Include(x => x.EducationLevel)
                        .Include(x => x.ForeignLanguage.Language)
                        .Include(x => x.ForeignLanguage.LanguageLevel)
                        .Include(x => x.User);
                }

                if (city != 0)
                {
                    resumes = resumes.Where(s => s.CityId == city)
                        .Include(x => x.City)
                        .Include(x => x.Sex)
                        .Include(x => x.WorkExperience)
                        .Include(x => x.Salary.Currency)
                        .Include(x => x.EducationLevel)
                        .Include(x => x.ForeignLanguage.Language)
                        .Include(x => x.ForeignLanguage.LanguageLevel)
                        .Include(x => x.User);
                }

                if (experience != 0)
                {
                    resumes = resumes.Where(s => s.WorkExperienceId == experience)
                        .Include(x => x.City)
                        .Include(x => x.Sex)
                        .Include(x => x.WorkExperience)
                        .Include(x => x.Salary.Currency)
                        .Include(x => x.EducationLevel)
                        .Include(x => x.ForeignLanguage.Language)
                        .Include(x => x.ForeignLanguage.LanguageLevel)
                        .Include(x => x.User);
                }

                return View(await resumes.OrderByDescending(v => v.CreationDate).ToListAsync());
            }
            else
            {
                return RedirectToAction("CompanyLogin", "Account");
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SendMailToCandidate(string title, string text, int id)
        {
            try
            {
                var company = _context.Companies.FirstOrDefault(elem => elem.Email == User.Identity.Name);
                if(company != null)
                {
                    var resume = _context.Resume.FirstOrDefault(i => i.Id == id);
                    if (resume != null)
                    {
                        var user = _context.Users.FirstOrDefault(i => i.Id == resume.UserId);
                                                
                        Service.SendEmailToCandidate(company.Name, company.Email, user.Email, title, text);
                    }
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetPartialMail(int id)
        {
            return PartialView("SendMailToCandidate");           
        }

        private static void DeletePDFFiles()
        {
            DirectoryInfo dirInfo = new("wwwroot/files/");
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
