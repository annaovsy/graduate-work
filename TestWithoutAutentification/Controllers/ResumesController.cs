using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWithoutAutentification.Models;
using TestWithoutAutentification.Models.AdditionalModels;
using System;
using System.Web;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace TestWithoutAutentification.Controllers
{
    [Authorize(Roles = "user")]
    public class ResumesController : Controller
    {
        private readonly AppDbContext _context;
     
        public ResumesController(AppDbContext context)
        {
            _context = context;
        }

        // get: resumes/details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resume = await _context.Resume
                .Include(x => x.City)
                .Include(x => x.Sex)
                .Include(x => x.WorkExperience)
                .Include(x => x.Salary.Currency)
                .Include(x => x.EducationLevel)
                .Include(x => x.ForeignLanguage.Language)
                .Include(x => x.ForeignLanguage.LanguageLevel)
                .Include(x => x.Specialization)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resume == null)
            {
                return NotFound();
            }

            return View(resume);
        }

        // get: resumes/create
        public IActionResult Create()
        {
            var user = _context.Users.Include(u => u.Resume).FirstOrDefault(elem => elem.Email == User.Identity.Name);
            if (user.Resume != null)
                return RedirectToAction("Details", "Resumes", new { user.Resume.Id });

            ViewBag.Cities = new SelectList(_context.City.OrderBy(e => e.Name), "Id", "Name");
            ViewBag.Sex = new SelectList(_context.Sex, "Id", "Name");
            ViewBag.WorkExperiences = new SelectList(_context.WorkExperience, "Id", "Name");
            ViewBag.Currencies = new SelectList(_context.Currency, "Id", "Name");
            ViewBag.EducationLevels = new SelectList(_context.EducationLevel, "Id", "Name");
            ViewBag.Languages = new SelectList(_context.Language.OrderBy(e => e.Name), "Id", "Name");
            ViewBag.LanguageLevels = new SelectList(_context.LanguageLevel, "Id", "Name");
            ViewBag.Specializations = new SelectList(_context.Specialization, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult CreatePlacesOfWork(PlaceOfWork placeOfWork)
        {
                _context.PlaceOfWork.Add(placeOfWork);
                _context.SaveChanges();
            // places.Add(new PlaceOfWork());
            //if(_resumeCreateModel.PlasesOfWorkId == null)
            //    _resumeCreateModel.PlasesOfWorkId = new List<int>(placeOfWork.Id);                
            //else
            //    _resumeCreateModel.PlasesOfWorkId.Add(placeOfWork.Id);

            //return RedirectToAction("Create", "Resumes");
            // return Content(placeOfWork.Organization);
            //return LocalRedirect("/Create/Resumes");
         
            return PartialView("_CreatePlacesOfWork", placeOfWork);
        }

       
        // post: resumes/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Resume resume)
        {
            if (ModelState.IsValid)
            {                
                resume.User = _context.Users.FirstOrDefault(elem => elem.Email == User.Identity.Name);
                if (resume.ForeignLanguage.LanguageId == 0)
                    resume.ForeignLanguage = _context.ForeignLanguage.FirstOrDefault(el => el.Id == 1);
                
                resume.CreationDate = DateTime.Now;
                _context.Resume.Add(resume);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Cities = new SelectList(_context.City.OrderBy(e => e.Name), "Id", "Name");
            ViewBag.Sex = new SelectList(_context.Sex, "Id", "Name");
            ViewBag.WorkExperiences = new SelectList(_context.WorkExperience, "Id", "Name");
            ViewBag.Currencies = new SelectList(_context.Currency, "Id", "Name");
            ViewBag.EducationLevels = new SelectList(_context.EducationLevel, "Id", "Name");
            ViewBag.Languages = new SelectList(_context.Language.OrderBy(e => e.Name), "Id", "Name");
            ViewBag.LanguageLevels = new SelectList(_context.LanguageLevel, "Id", "Name");
            ViewBag.Specializations = new SelectList(_context.Specialization, "Id", "Name");

            return View(resume);
        }

        // get: resumes/edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resume = await _context.Resume.Include(x => x.City)
                                        .Include(x => x.Sex)
                                        .Include(x => x.WorkExperience)
                                        .Include(x => x.Salary.Currency)
                                        .Include(x => x.EducationLevel)
                                        .Include(x => x.User)
                                        .Include(x => x.ForeignLanguage.Language)
                                        .Include(x => x.ForeignLanguage.LanguageLevel)
                                        .Include(x => x.Specialization)
                                        .FirstOrDefaultAsync(v => v.Id == id);
            if (resume == null)
            {
                return NotFound();
            }

            ViewBag.Cities = new SelectList(_context.City.OrderBy(e => e.Name), "Id", "Name");
            ViewBag.Sex = new SelectList(_context.Sex, "Id", "Name");
            ViewBag.WorkExperiences = new SelectList(_context.WorkExperience, "Id", "Name");
            ViewBag.Currencies = new SelectList(_context.Currency, "Id", "Name");
            ViewBag.EducationLevels = new SelectList(_context.EducationLevel, "Id", "Name");
            ViewBag.Languages = new SelectList(_context.Language.OrderBy(e => e.Name), "Id", "Name");
            ViewBag.LanguageLevels = new SelectList(_context.LanguageLevel, "Id", "Name");
            ViewBag.Specializations = new SelectList(_context.Specialization, "Id", "Name");

            return View(resume);
        }

        // post: resumes/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Resume resume)
        {
            if (id != resume.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResumeExists(resume.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Cities = new SelectList(_context.City.OrderBy(e => e.Name), "Id", "Name");
            ViewBag.Sex = new SelectList(_context.Sex, "Id", "Name");
            ViewBag.WorkExperiences = new SelectList(_context.WorkExperience, "Id", "Name");
            ViewBag.Currencies = new SelectList(_context.Currency, "Id", "Name");
            ViewBag.EducationLevels = new SelectList(_context.EducationLevel, "Id", "Name");
            ViewBag.Languages = new SelectList(_context.Language.OrderBy(e => e.Name), "Id", "Name");
            ViewBag.LanguageLevels = new SelectList(_context.LanguageLevel, "Id", "Name");
            ViewBag.Specializations = new SelectList(_context.Specialization, "Id", "Name");

            return View(resume);
        }

        // get: resumes/delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resume = await _context.Resume
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resume == null)
            {
                return NotFound();
            }

            return View(resume);
        }

        // post: resumes/delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resume = await _context.Resume.FindAsync(id);
            _context.Resume.Remove(resume);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool ResumeExists(int id)
        {
            return _context.Resume.Any(e => e.Id == id);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ShowResume(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("company"))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var resume = await _context.Resume
                    .Include(x => x.City)
                    .Include(x => x.Sex)
                    .Include(x => x.WorkExperience)
                    .Include(x => x.Salary.Currency)
                    .Include(x => x.EducationLevel)
                    .Include(x => x.ForeignLanguage.Language)
                    .Include(x => x.ForeignLanguage.LanguageLevel)
                    .Include(x => x.Specialization)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (resume == null)
                {
                    return NotFound();
                }

                Service.CreatePDF(resume);

                return View(resume);
            }
            else
            {
                return RedirectToAction("CompanyLogin", "Account");
            }           
        }
    }
}
