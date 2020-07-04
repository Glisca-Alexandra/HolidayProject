using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Holiday.DataBaseContext;
using Holiday.Models;
using Holiday.Services.Interfaces;
using Holiday.Repositories.Interfaces;

namespace Holiday.Controllers
{
    public class VacantionsController : Controller
    {
        private readonly HolidayContext _context;
        private readonly IVacantion _vacantion;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public VacantionsController(IVacantion vacantion,IRepositoryWrapper repositoryWrapper)
        {
            _vacantion = vacantion;
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: Vacantions
        public IActionResult Index()
        {
            var vacantions = _vacantion.GetAllVacantions();

            return View(vacantions);
        }

        // GET: Vacantions/Details/5
        public IActionResult Details(string VacantionId)
        {
            if (VacantionId == null)
            {
                return NotFound();
            }

            var vacantion = _vacantion.GetVacantionById(VacantionId);
                
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
        public IActionResult Create([Bind("VacantionId,VacantionType,VacantionDays")] Vacantion vacantion)
        {
            if (ModelState.IsValid)
            {
                _vacantion.CreateVacantion(vacantion);
                _repositoryWrapper.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(vacantion);
        }

        // GET: Vacantions/Edit/5
        public IActionResult Edit(/*string VacantionId*/)
        {
            //if (VacantionId == null)
            //{
            //    return NotFound();
            //}

            //var vacantion = _vacantion.GetVacantionById(VacantionId);
            //if (vacantion == null)
            //{
            //    return NotFound();
            //}
            //return View(vacantion);
            return View();
        }

        // POST: Vacantions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string VacantionId, [Bind("VacantionId,VacantionType,VacantionDays")] Vacantion vacantion)
        {
            if (VacantionId != vacantion.VacantionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               // try
               // {
                    _vacantion.EditVacantion(vacantion);
                    _repositoryWrapper.Save();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!VacantionExists(vacantion.VacantionId))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(Index));
            }
            return View(vacantion);
        }

        private bool VacantionExists(string VacantionId)
        {
            throw new NotImplementedException();
        }

        // GET: Vacantions/Delete/5
        public IActionResult Delete(string VacantionId)
        {
            if (VacantionId == null)
            {
                return NotFound();
            }

            var vacantion = _vacantion.GetVacantionById(VacantionId);
              
            if (vacantion == null)
            {
                return NotFound();
            }

            return View(vacantion);
        }

        // POST: Vacantions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string VacantionId)
        {
            var vacantion = _vacantion.GetVacantionById(VacantionId);
            _vacantion.DeleteVacantion(vacantion);
            _repositoryWrapper.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool VacantionExists(string id)
        //{
        //    return _context.Vacantions.Any(e => e.VacantionId == id);
        //}
    }
}
