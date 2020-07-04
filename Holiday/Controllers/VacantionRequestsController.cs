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

namespace Holiday.Controllers
{
    public class VacantionRequestsController : Controller
    {
        private readonly HolidayContext _context;
        private readonly IVacantionRequest _vacantionRequest;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public VacantionRequestsController(IVacantionRequest vacantionRequest, IRepositoryWrapper repositoryWrapper)
        {
            _vacantionRequest = vacantionRequest;
            _repositoryWrapper = repositoryWrapper;
        }
        // GET: VacantionRequests
        public IActionResult Index()
        {
            var vacantionRequests = _vacantionRequest.GetAllVacantionRequests();

            return View(vacantionRequests);
        }


        // GET: VacantionRequests/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var vacantionRequest = await _context.VacantionRequests
        //        .FirstOrDefaultAsync(m => m.VacantionRequestId == id);
        //    if (vacantionRequest == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(vacantionRequest);
        //}

        // GET: VacantionRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VacantionRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("VacantionRequestId,FirstName,LastName,Type,NoOfDays,Cause")] VacantionRequest vacantionRequest)
        {
            if (ModelState.IsValid)
            {
                _vacantionRequest.CreateVacantionRequest(vacantionRequest);
                _repositoryWrapper.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(vacantionRequest);
        }

        // GET: VacantionRequests/Edit/5
    //    public async Task<IActionResult> Edit(string id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var vacantionRequest = await _context.VacantionRequests.FindAsync(id);
    //        if (vacantionRequest == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(vacantionRequest);
    //    }

    //    // POST: VacantionRequests/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(string id, [Bind("VacantionRequestId,FirstName,LastName,Type,NoOfDays,Cause")] VacantionRequest vacantionRequest)
    //    {
    //        if (id != vacantionRequest.VacantionRequestId)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(vacantionRequest);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!VacantionRequestExists(vacantionRequest.VacantionRequestId))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(vacantionRequest);
    //    }

    //    // GET: VacantionRequests/Delete/5
    //    public async Task<IActionResult> Delete(string id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var vacantionRequest = await _context.VacantionRequests
    //            .FirstOrDefaultAsync(m => m.VacantionRequestId == id);
    //        if (vacantionRequest == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(vacantionRequest);
    //    }

    //    // POST: VacantionRequests/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(string id)
    //    {
    //        var vacantionRequest = await _context.VacantionRequests.FindAsync(id);
    //        _context.VacantionRequests.Remove(vacantionRequest);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool VacantionRequestExists(string id)
    //    {
    //        return _context.VacantionRequests.Any(e => e.VacantionRequestId == id);
    //    }
    }
}
