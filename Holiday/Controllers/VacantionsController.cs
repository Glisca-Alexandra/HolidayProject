using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Holiday.DataBaseContext;
using Holiday.Models;

namespace Holiday.Controllers
{
    public class VacantionsController : Controller
    {
        private readonly HolidayContext _context;

        public VacantionsController(HolidayContext context)
        {
            _context = context;
        }

        // GET: Vacantions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vacantions.ToListAsync());
        }

        // GET: Vacantions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacantion = await _context.Vacantions
                .FirstOrDefaultAsync(m => m.VacantionId == id);
            if (vacantion == null)
            {
                return NotFound();
            }

            return View(vacantion);
        }

        // GET: Vacantions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vacantions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacantionId,VacantionType,VacantionDays")] Vacantion vacantion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacantion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacantion);
        }

        // GET: Vacantions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacantion = await _context.Vacantions.FindAsync(id);
            if (vacantion == null)
            {
                return NotFound();
            }
            return View(vacantion);
        }

        // POST: Vacantions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VacantionId,VacantionType,VacantionDays")] Vacantion vacantion)
        {
            if (id != vacantion.VacantionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacantion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacantionExists(vacantion.VacantionId))
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
            return View(vacantion);
        }

        // GET: Vacantions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacantion = await _context.Vacantions
                .FirstOrDefaultAsync(m => m.VacantionId == id);
            if (vacantion == null)
            {
                return NotFound();
            }

            return View(vacantion);
        }

        // POST: Vacantions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vacantion = await _context.Vacantions.FindAsync(id);
            _context.Vacantions.Remove(vacantion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacantionExists(string id)
        {
            return _context.Vacantions.Any(e => e.VacantionId == id);
        }
    }
}
