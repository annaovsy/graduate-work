using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestWithoutAutentification.Models;

namespace TestWithoutAutentification.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, int specialization, int city, int experience)
        {          
            var vacancies = _context.Vacancy
                   .Include(v => v.City)
                   .Include(v => v.Company.Image)
                   .Include(v => v.Salary.Currency)
                   .Include(v => v.WorkExperience)
                   .Include(v => v.Specialization);
            
            ViewBag.Specializations = new SelectList(_context.Specialization, "Id", "Name");
            ViewBag.Cities = new SelectList(_context.City, "Id", "Name");
            ViewBag.Experiences = new SelectList(_context.WorkExperience, "Id", "Name");

            if (!String.IsNullOrEmpty(searchString))
            {
                vacancies = vacancies.Where(s => s.Position!.Contains(searchString) 
                || s.Company.Name!.Contains(searchString))
                   .Include(v => v.City)
                   .Include(v => v.Company)
                   .Include(v => v.Salary.Currency)
                   .Include(v => v.WorkExperience)
                   .Include(v => v.Specialization);
            }

            if (specialization != 0)
            {
                vacancies = vacancies.Where(s => s.SpecializationId == specialization)
                   .Include(v => v.City)
                   .Include(v => v.Company)
                   .Include(v => v.Salary.Currency)
                   .Include(v => v.WorkExperience)
                   .Include(v => v.Specialization);
            }

            if (city != 0)
            {
                vacancies = vacancies.Where(s => s.CityId == city)
                   .Include(v => v.City)
                   .Include(v => v.Company)
                   .Include(v => v.Salary.Currency)
                   .Include(v => v.WorkExperience)
                   .Include(v => v.Specialization);
            }

            if (experience != 0)
            {
                vacancies = vacancies.Where(s => s.WorkExperienceId == experience)
                   .Include(v => v.City)
                   .Include(v => v.Company)
                   .Include(v => v.Salary.Currency)
                   .Include(v => v.WorkExperience)
                   .Include(v => v.Specialization);
            }

            return View(await vacancies.OrderByDescending(v => v.CreationDate).ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SendResponseToCompany(string text, int id)
        {
            try
            {
                var resume = _context.Resume.Include(elem => elem.User)
                                .FirstOrDefault(elem => elem.User.Email == User.Identity.Name);
                var vacancy = _context.Vacancy.Include(i => i.Company)
                                .FirstOrDefault(i => i.Id == id);
                if (vacancy != null)
                {
                    Service.SendEmailToCompany(resume.FullName, resume.User.Email, resume.Id, vacancy.Id, vacancy.Position, vacancy.Company.Email, text);
                }         
            }
            catch (Exception e)
            {

            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetPartialMail(int id)
        {
            if(User.Identity.IsAuthenticated && User.IsInRole("user"))
            {
                var resume = _context.Resume.FirstOrDefault(elem => elem.User.Email == User.Identity.Name);
                if (resume != null)
                    return PartialView("SendResponseToCompany");
                else
                    ViewBag.Message = "Для отклика необходимо создать резюме";                   
            }
            else
                ViewBag.Message = "Необходимо зарегистрироваться";

            return PartialView("_GeneralModal");         
        }

        public async Task<IActionResult> PersonalArea()
        {
            var user = _context.Users.Include(u => u.Resume)
                        .FirstOrDefault(i => i.Email == User.Identity.Name);           

            return View(user);
        }
    }
}
