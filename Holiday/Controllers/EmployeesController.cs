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
    public class EmployeesController : Controller
    {
       // private readonly HolidayContext _context;
        private readonly IEmployee _employee;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public EmployeesController(IEmployee employee, IRepositoryWrapper repositoryWrapper)
        {
            _employee = employee;
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: Employees
        public IActionResult Index()
        {
            var employees = _employee.GetAllEmployees();

            return View(employees);
        }

        // GET: Employees/Details/5
        public IActionResult Details(string employeeId)
        {
            var view = _employee.GetEmployeeById(employeeId);
            if (view == null)
            {
                return NotFound();
            }
            return View(view);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,NumberOfDays")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employee.AddEmployee(employee);
                _repositoryWrapper.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(string employeeId)
        {
            if (employeeId == null)
            {
                return NotFound();
            }

            var employee = _employee.GetEmployeeById(employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string employeeId, [Bind("EmployeeId,FirstName,LastName,NumberOfDays")] Employee employee)
        {
            if (employeeId != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _employee.EditEmployee(employee);
                    _repositoryWrapper.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

        private bool EmployeeExists(string employeeId)
        {
            throw new NotImplementedException();
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(string employeeId)
        {
            if (employeeId == null)
            {
                return NotFound();
            }

            var employee = _employee.GetEmployeeById(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string employeeId)
        {
            var employee = _employee.GetEmployeeById(employeeId);
            _employee.DeleteEmployee(employee);
            _repositoryWrapper.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool EmployeeExists(string employeeId)
        //{
        //    return _repositoryWrapper.Employee.Any(e => e.EmployeeId == id);
        //}
    }
}
