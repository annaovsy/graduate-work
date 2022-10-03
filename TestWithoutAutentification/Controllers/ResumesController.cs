using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWithoutAutentification.Models;
using TestWithoutAutentification.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using TestWithoutAutentification.Models.AdditionalModels;

namespace TestWithoutAutentification.Controllers
{
    public class ResumesController : Controller
    {
        private readonly AppDbContext _context;
        private List<int> items = new List<int>();

        public ResumesController(AppDbContext context)
        {
            _context = context;
            // _user = user;
        }

        // get: resumes
        public async Task<IActionResult> Index()
        {
            var resume = _context.Resume.Include(x => x.City)
                                        .Include(x => x.Sex)
                                        .Include(x => x.Citizenships)
                                        .Include(x => x.WorkExperience)
                                        .Include(x => x.Salary.Currency).ToListAsync();
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resume == null)
            {
                return NotFound();
            }

            return View(resume);
        }

        // get: resumes/create
        public IActionResult Create(PlaceOfWork placeOfWork)
        {
            SelectList cities = new SelectList(_context.City, "Id", "Name");
            ViewBag.Cities = cities;

            SelectList sex = new SelectList(_context.Sex, "Id", "Name");
            ViewBag.Sex = sex;

            MultiSelectList citizenship = new MultiSelectList(_context.Citizenship, "Id", "Name");
            ViewBag.Citizenships = citizenship;

            SelectList experience = new SelectList(_context.WorkExperience, "Id", "Name");
            ViewBag.WorkExperiences = experience;

            SelectList currency = new SelectList(_context.Currency, "Id", "Name");
            ViewBag.Currencies = currency;

            //SelectList plaseOfWork = new SelectList(_context.PlaceOfWork, "Id");
            //ViewBag.PlaceOfWork = placeOfWork.Id;
            // ViewBag.PlaceOfWork = PlasesOfWorkId;
            items.Add(placeOfWork.Id);            
            ViewBag.PlaceOfWorkId = items;

            return View();
        }

        // post: resumes/create
        // to protect from overposting attacks, enable the specific properties you want to bind to.
        // for more details, see http://go.microsoft.com/fwlink/?linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[bind("id,firstname,lastname,mobilephone,dateofbirth,position,aboutmyself,citizenshipid,placeofworkid,educationalinstitutionid,foreignlanguageid")]*/ ResumeCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == "ane4ka.sax@mail.ru");
                                
                var salary = new Salary { Amount = model.Salary, CurrencyId = model.CurrencyId };
                if(salary == null)
                    return View(model);
                else
                    _context.Salary.Add(salary);
                
                // добавляем резюме в бд
                Resume resume = new Resume
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MobilePhone = model.MobilePhone,
                    CityId = model.CityId,
                    SexId = model.SexId,
                    DateOfBirth = model.DateOfBirth,
                    WorkExperienceId = model.WorkExperienceId,
                    Position = model.Position,
                    Salary = salary,
                    AboutMyself = model.AboutMyself,
                    User = user
                };
                foreach (var id in model.CitizenshipsId)
                {
                    Citizenship citizenship = _context.Citizenship.FirstOrDefault(u => u.Id == id);
                    resume.Citizenships.Add(citizenship);
                }
                if(model.PlasesOfWorkId != null)
                {
                    foreach (var id in model.PlasesOfWorkId)
                    {
                        PlaceOfWork placeOfWork = _context.PlaceOfWork.FirstOrDefault(u => u.Id == id);
                        resume.PlacesOfWork.Add(placeOfWork);
                    }
                }
              
                _context.Resume.Add(resume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // get: resumes/edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resume = await _context.Resume.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, /*[bind("id,firstname,lastname,mobilephone,dateofbirth,position,aboutmyself,citizenshipid,placeofworkid,educationalinstitutionid,foreignlanguageid")]*/ Resume resume)
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
                return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
        }

        private bool ResumeExists(int id)
        {
            return _context.Resume.Any(e => e.Id == id);
        }
    }
}
