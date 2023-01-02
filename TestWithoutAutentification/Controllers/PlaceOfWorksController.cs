using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWithoutAutentification.Models;
using TestWithoutAutentification.Models.AdditionalModels;
using TestWithoutAutentification.ViewModels;

namespace TestWithoutAutentification.Controllers
{
    public class PlaceOfWorksController : Controller
    {
        private readonly AppDbContext _context;
        private ResumeCreateModel _resumeCreateModel { get; set; }

        public PlaceOfWorksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PlaceOfWorks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PlaceOfWork.Include(p => p.Resume);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PlaceOfWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeOfWork = await _context.PlaceOfWork
                .Include(p => p.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placeOfWork == null)
            {
                return NotFound();
            }

            return View(placeOfWork);
        }

        // GET: PlaceOfWorks/Create
        public IActionResult Create(ResumeCreateModel resume)
        {
            // ViewData["ResumeId"] = new SelectList(_context.Resume, "Id");
            //PlaceOfWork placeOfWork = new PlaceOfWork();
            _resumeCreateModel = resume;
            return View();
        }

        // POST: PlaceOfWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Organization,Position,ResumeId")] PlaceOfWork placeOfWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placeOfWork);
                await _context.SaveChangesAsync();
                //if(_resumeCreateModel.PlasesOfWorkId == null)
                //    _resumeCreateModel.PlasesOfWorkId = new List<int>(placeOfWork.Id);                
                //else
                //    _resumeCreateModel.PlasesOfWorkId.Add(placeOfWork.Id);

                return RedirectToAction("Create", "Resumes", _resumeCreateModel/*new { placeId = placeOfWork.Id }*/ );
            }
            //ViewData["ResumeId"] = new SelectList(_context.Resume, "Id", "Id", placeOfWork.ResumeId);
            return View(placeOfWork);
        }

        // GET: PlaceOfWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeOfWork = await _context.PlaceOfWork.FindAsync(id);
            if (placeOfWork == null)
            {
                return NotFound();
            }
            ViewData["ResumeId"] = new SelectList(_context.Resume, "Id", "Id", placeOfWork.ResumeId);
            return View(placeOfWork);
        }

        // POST: PlaceOfWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,Organization,Position,ResumeId")] PlaceOfWork placeOfWork)
        {
            if (id != placeOfWork.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placeOfWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceOfWorkExists(placeOfWork.Id))
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
            ViewData["ResumeId"] = new SelectList(_context.Resume, "Id", "Id", placeOfWork.ResumeId);
            return View(placeOfWork);
        }

        // GET: PlaceOfWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeOfWork = await _context.PlaceOfWork
                .Include(p => p.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placeOfWork == null)
            {
                return NotFound();
            }

            return View(placeOfWork);
        }

        // POST: PlaceOfWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placeOfWork = await _context.PlaceOfWork.FindAsync(id);
            _context.PlaceOfWork.Remove(placeOfWork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaceOfWorkExists(int id)
        {
            return _context.PlaceOfWork.Any(e => e.Id == id);
        }
    }
}
