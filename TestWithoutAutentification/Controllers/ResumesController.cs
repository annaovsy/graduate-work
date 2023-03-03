using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWithoutAutentification.Models;
using System;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Windows.Web.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TestWithoutAutentification.Models.AdditionalModels;

namespace TestWithoutAutentification.Controllers
{
    [Authorize(Roles = "user")]
    public class ResumesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public ResumesController(AppDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
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
                .Include(x => x.Gender)
                .Include(x => x.WorkExperience)
                .Include(x => x.Salary.Currency)
                .Include(x => x.EducationLevel)
                .Include(x => x.ForeignLanguage.Language)
                .Include(x => x.ForeignLanguage.LanguageLevel)
                .Include(x => x.Specialization)
                .Include(x => x.Image)
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
            ViewBag.Gender = new SelectList(_context.Gender, "Id", "Name");
            ViewBag.WorkExperiences = new SelectList(_context.WorkExperience, "Id", "Name");
            ViewBag.Currencies = new SelectList(_context.Currency, "Id", "Name");
            ViewBag.EducationLevels = new SelectList(_context.EducationLevel, "Id", "Name");
            ViewBag.Languages = new SelectList(_context.Language.OrderBy(e => e.Name), "Id", "Name");
            ViewBag.LanguageLevels = new SelectList(_context.LanguageLevel, "Id", "Name");
            ViewBag.Specializations = new SelectList(_context.Specialization, "Id", "Name");

            return View();
        }
                  
        // post: resumes/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Resume resume, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                resume.User = _context.Users.FirstOrDefault(elem => elem.Email == User.Identity.Name);
                if (resume.ForeignLanguage.LanguageId == 0)
                    resume.ForeignLanguage = _context.ForeignLanguage.FirstOrDefault(el => el.Id == 1);

                if (uploadedFile != null)
                {
                    string path = "/avatar/" + uploadedFile.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    Image file = new() { Name = uploadedFile.FileName, Path = path };
                    _context.Images.Add(file);
                    resume.Image = file;
                }                

                resume.CreationDate = DateTime.Now;
                _context.Resume.Add(resume);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Cities = new SelectList(_context.City.OrderBy(e => e.Name), "Id", "Name");
            ViewBag.Gender = new SelectList(_context.Gender, "Id", "Name");
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
                                        .Include(x => x.Gender)
                                        .Include(x => x.WorkExperience)
                                        .Include(x => x.Salary.Currency)
                                        .Include(x => x.EducationLevel)
                                        .Include(x => x.User)
                                        .Include(x => x.ForeignLanguage.Language)
                                        .Include(x => x.ForeignLanguage.LanguageLevel)
                                        .Include(x => x.Specialization)
                                        .Include(x => x.Image)
                                        .FirstOrDefaultAsync(v => v.Id == id);
            if (resume == null)
            {
                return NotFound();
            }

            ViewBag.Cities = new SelectList(_context.City.OrderBy(e => e.Name), "Id", "Name");
            ViewBag.Gender = new SelectList(_context.Gender, "Id", "Name");
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
        public async Task<IActionResult> Edit(int id, Resume resume, IFormFile uploadedFile)
        {
            if (id != resume.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (uploadedFile != null)
                    {
                        if (resume.ImageId != null)
                        {
                            DirectoryInfo dirInfo = new(_appEnvironment.WebRootPath + "/avatar/");
                            var currImg = _context.Images.FirstOrDefault(e => e.Id == resume.ImageId);
                            var file = dirInfo.GetFiles().Where(e => e.Name == currImg.Name).FirstOrDefault();
                            _context.Images.Remove(currImg);
                            file.Delete();
                        }

                        string path = "/avatar/" + uploadedFile.FileName;

                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }
                        Image img = new() { Name = uploadedFile.FileName, Path = path };
                        _context.Images.Add(img);
                        resume.Image = img;
                    }
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
            ViewBag.Gender = new SelectList(_context.Gender, "Id", "Name");
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

            var resume = await _context.Resume.Include(e => e.Image)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resume == null)
            {
                return NotFound();
            }
            if (resume.Image != null)
            {
                DirectoryInfo dirInfo = new(_appEnvironment.WebRootPath + "/avatar/");
                var currImg = _context.Images.FirstOrDefault(e => e.Id == resume.Image.Id);
                var file = dirInfo.GetFiles().Where(e => e.Name == currImg.Name).FirstOrDefault();
                _context.Images.Remove(currImg);
                file.Delete();
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
                    .Include(x => x.Gender)
                    .Include(x => x.WorkExperience)
                    .Include(x => x.Salary.Currency)
                    .Include(x => x.EducationLevel)
                    .Include(x => x.ForeignLanguage.Language)
                    .Include(x => x.ForeignLanguage.LanguageLevel)
                    .Include(x => x.Specialization)
                    .Include(x => x.Image)
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
