using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Holiday.DataBaseContext;
using Holiday.Models;
using Holiday.Repositories.Interfaces;
using Holiday.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Holiday.Controllers
{
    public class VacantionRequestsController : Controller
    {
        private readonly HolidayContext _context;
  

        public VacantionRequestsController(HolidayContext context)
        {
           
            _context = context;
        }
        // GET: VacantionRequests
        [Authorize(Roles="Operational,Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.VacantionRequests.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index1()
        {
            return View(await _context.VacantionRequests.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index2()
        {
            return View(await _context.VacantionRequests.ToListAsync());
        }

        [Authorize(Roles = "Operational,Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holidayRequest = await _context.VacantionRequests
                .FirstOrDefaultAsync(m => m.VacantionRequestId == id);
            if (holidayRequest == null)
            {
                return NotFound();
            }

            return View(holidayRequest);
        }


        // GET: VacantionRequests/Create
        [Authorize(Roles = "Operational")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: VacantionRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacantionRequestId,FirstName,LastName,Type,StartDate,NoOfDays,Cause")] VacantionRequest vacantionRequest)
        {
            if (ModelState.IsValid)
            {
          
                _context.Add(vacantionRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacantionRequest);
        }

        // GET: VacantionRequests/Edit/5
        [Authorize(Roles = "Operational")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacantionRequest = await _context.VacantionRequests.FindAsync(id);
            if (vacantionRequest == null)
            {
                return NotFound();
            }
            return View(vacantionRequest);
        }

        // POST: VacantionRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operational")]
        public async Task<IActionResult> Edit(string id, [Bind("VacantionRequestId,FirstName,LastName,Type,StartDate,NoOfDays,Cause")] VacantionRequest vacantionRequest)
        {
            if (id != vacantionRequest.VacantionRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacantionRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacantionRequestExists(vacantionRequest.VacantionRequestId))
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
            return View(vacantionRequest);
        }

        // GET: VacantionRequests/Delete/5
        [Authorize(Roles = "Operational,Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacantionRequest = await _context.VacantionRequests
                .FirstOrDefaultAsync(m => m.VacantionRequestId == id);
            if (vacantionRequest == null)
            {
                return NotFound();
            }

            return View(vacantionRequest);
        }

        // POST: VacantionRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operational,Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vacantionRequest = await _context.VacantionRequests.FindAsync(id);
            _context.VacantionRequests.Remove(vacantionRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacantionRequestExists(string id)
        {
            return _context.VacantionRequests.Any(e => e.VacantionRequestId == id);
        }
    }
}
