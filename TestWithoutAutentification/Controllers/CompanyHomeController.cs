using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        
        public async Task<IActionResult> Index(string searchString)
        {
            if(User.Identity.IsAuthenticated && User.IsInRole("company"))
            {
                var resumes = _context.Resume.Include(x => x.City)
                                        .Include(x => x.Sex)
                                        .Include(x => x.WorkExperience)
                                        .Include(x => x.Salary.Currency)
                                        .Include(x => x.EducationLevel)
                                        .Include(x => x.ForeignLanguage.Language)
                                        .Include(x => x.ForeignLanguage.LanguageLevel)
                                        .Include(x => x.User);

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

                return View(await resumes.ToListAsync());
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
    }
}
