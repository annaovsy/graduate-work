using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWithoutAutentification.Models;
using TestWithoutAutentification.Models.AdditionalModels;
using Microsoft.AspNetCore.Authorization;
using System;

namespace TestWithoutAutentification.Controllers
{
    [Authorize]
    public class ResumesController : Controller
    {
        private readonly AppDbContext _context;
        SelectList cities;
        SelectList sex;
        MultiSelectList citizenship;
        SelectList experience;
        SelectList currency;
        SelectList educationLevel;
        SelectList language;
        SelectList languageLevel;

        public ResumesController(AppDbContext context)
        {
            _context = context;

            cities = new SelectList(_context.City, "Id", "Name"); 
            sex = new SelectList(_context.Sex, "Id", "Name");
            citizenship = new MultiSelectList(_context.Citizenship, "Id", "Name");
            experience = new SelectList(_context.WorkExperience, "Id", "Name");
            currency = new SelectList(_context.Currency, "Id", "Name");
            educationLevel = new SelectList(_context.EducationLevel, "Id", "Name");
            language = new SelectList(_context.Language, "Id", "Name");
            languageLevel = new SelectList(_context.LanguageLevel, "Id", "Name");
        }

        // get: resumes
        public async Task<IActionResult> Index()
        {
          
            var resume = _context.Resume.Include(x => x.City)
                                        .Include(x => x.Sex)
                                        .Include(x => x.Citizenships)
                                        .Include(x => x.WorkExperience)
                                        .Include(x => x.Salary.Currency)
                                        .Include(x => x.EducationLevel).ToListAsync();
            return View(await resume);
            //return view(await _context.resume.tolistasync());
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
                .Include(x => x.Citizenships)
                .Include(x => x.WorkExperience)
                .Include(x => x.Salary.Currency)
                .Include(x => x.EducationLevel)
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

            ViewBag.Cities = cities;
            ViewBag.Sex = sex;
            ViewBag.Citizenships = citizenship;
            ViewBag.WorkExperiences = experience;
            ViewBag.Currencies = currency;
            ViewBag.EducationLevels = educationLevel;
            ViewBag.Languages = language;
            ViewBag.LanguageLevels = languageLevel;

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
        // to protect from overposting attacks, enable the specific properties you want to bind to.
        // for more details, see http://go.microsoft.com/fwlink/?linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Resume resume)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in resume.CitizenshipsId)
                {
                    Citizenship citizenship = _context.Citizenship.FirstOrDefault(elem => elem.Id == item);
                    resume.Citizenships.Add(citizenship);
                }
                
                resume.User = _context.Users.FirstOrDefault(elem => elem.Email == User.Identity.Name);

                // добавляем резюме в бд
                //Resume resume = new Resume
                //{
                //    FirstName = model.FirstName,
                //    LastName = model.LastName,
                //    MobilePhone = model.MobilePhone,
                //    CityId = model.City.Id,
                //    SexId = model.Sex.Id,
                //    DateOfBirth = model.DateOfBirth,
                //    WorkExperienceId = model.WorkExperience.Id,
                //    EducationLevelId = model.EducationLevel.Id,
                //    Position = model.Position,
                //    Salary = model.Salary,
                //    AboutMyself = model.AboutMyself
                //};
                //foreach (var item in model.CitizenshipsId)
                //{
                //    Citizenship citizenship = _context.Citizenship.FirstOrDefault(elem => elem.Id == item);
                //    resume.Citizenships.Add(citizenship);
                //}
                //resume.User = _context.Users.FirstOrDefault(elem => elem.Email == User.Identity.Name);


                _context.Resume.Add(resume);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(resume);
        }

        // get: resumes/edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Cities = cities;
            ViewBag.Sex = sex;
            ViewBag.Citizenships = citizenship;
            ViewBag.WorkExperiences = experience;
            ViewBag.Currencies = currency;
            ViewBag.EducationLevels = educationLevel;
            ViewBag.Languages = language;
            ViewBag.LanguageLevels = languageLevel;

            if (id == null)
            {
                return NotFound();
            }

            var resume = await _context.Resume.Include(x => x.City)
                                        .Include(x => x.Sex)
                                        .Include(x => x.Citizenships)
                                        .Include(x => x.WorkExperience)
                                        .Include(x => x.Salary.Currency)
                                        .Include(x => x.EducationLevel)
                                        .Include(x => x.User)
                                        .FirstOrDefaultAsync(v => v.Id == id);
            if (resume == null)
            {
                return NotFound();
            }
            return View(resume);
        }

        // post: resumes/edit/5
        // to protect from overposting attacks, enable the specific properties you want to bind to.
        // for more details, see http://go.microsoft.com/fwlink/?linkid=317598.
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

        public async Task<IActionResult> ShowResume(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resume = await _context.Resume
                .Include(x => x.City)
                .Include(x => x.Sex)
                .Include(x => x.Citizenships)
                .Include(x => x.WorkExperience)
                .Include(x => x.Salary.Currency)
                .Include(x => x.EducationLevel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resume == null)
            {
                return NotFound();
            }

            return View(resume);
        }
    }
}
