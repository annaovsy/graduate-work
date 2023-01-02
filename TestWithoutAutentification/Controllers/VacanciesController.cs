using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWithoutAutentification.Models;

namespace TestWithoutAutentification.Controllers
{
    public class VacanciesController : Controller
    {
        private readonly AppDbContext _context;

        public VacanciesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Vacancies
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Vacancy
                .Include(v => v.City)
                .Include(v => v.Company)
                .Include(v => v.Salary.Currency)
                .Include(v => v.WorkExperience)
                .Where(v => v.Company.Email == User.Identity.Name);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Vacancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy
                .Include(v => v.City)
                .Include(v => v.Company)
                .Include(v => v.Salary.Currency)
                .Include(v => v.WorkExperience)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // GET: Vacancies/Create
        public IActionResult Create()
        {
            ViewBag.Cities = new SelectList(_context.City, "Id", "Name");
            ViewBag.WorkExperiences = new SelectList(_context.WorkExperience, "Id", "Name");
            ViewBag.Currencies = new SelectList(_context.Currency, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                //vacancy.Requirements = vacancy.Requirements.Split("\r\n");
                //vacancy.Conditions = vacancy.Conditions.Replace("\r\n", "<br />");
                vacancy.Company = _context.Companies.FirstOrDefault(elem => elem.Email == User.Identity.Name);

                _context.Vacancy.Add(vacancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Cities = new SelectList(_context.City, "Id", "Name");
            ViewBag.WorkExperiences = new SelectList(_context.WorkExperience, "Id", "Name");
            ViewBag.Currencies = new SelectList(_context.Currency, "Id", "Name");

            return View(vacancy);
        }

        // GET: Vacancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy
                .Include(v => v.City)
                .Include(v => v.Company)
                .Include(v => v.Salary.Currency)
                .Include(v => v.WorkExperience)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }
            ViewBag.Cities = new SelectList(_context.City, "Id", "Name");
            ViewBag.WorkExperiences = new SelectList(_context.WorkExperience, "Id", "Name");
            ViewBag.Currencies = new SelectList(_context.Currency, "Id", "Name");
            return View(vacancy);
        }

        // POST: Vacancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vacancy vacancy)
        {
            if (id != vacancy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //vacancy.Requirements = vacancy.Requirements.Replace("\r\n", "<br>");
                    //vacancy.Conditions = vacancy.Conditions.Replace("\r\n", "<br>");
                    _context.Update(vacancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyExists(vacancy.Id))
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
            ViewBag.Cities = new SelectList(_context.City, "Id", "Name");
            ViewBag.WorkExperiences = new SelectList(_context.WorkExperience, "Id", "Name");
            ViewBag.Currencies = new SelectList(_context.Currency, "Id", "Name");
            return View(vacancy);
        }

        // GET: Vacancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy
                .Include(v => v.City)
                .Include(v => v.Company)
                .Include(v => v.Salary.Currency)
                .Include(v => v.WorkExperience)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancy = await _context.Vacancy.FindAsync(id);
            _context.Vacancy.Remove(vacancy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyExists(int id)
        {
            return _context.Vacancy.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ShowVacancy(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy
                .Include(v => v.City)
                .Include(v => v.Company)
                .Include(v => v.Salary.Currency)
                .Include(v => v.WorkExperience)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }
    }
}
