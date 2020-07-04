using Holiday.DataBaseContext;
using Holiday.Models;
using Holiday.Repositories.Interfaces;
using Holiday.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday.Services
{
    public class EmployeeService:IEmployee
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly HolidayContext _holidayContext;
        public EmployeeService(IRepositoryWrapper employee, HolidayContext holidayContext)
        {
            repositoryWrapper = employee;
            _holidayContext = holidayContext;

        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return repositoryWrapper.Employee.FindAll()
                .OrderBy(tl => tl.FirstName)
                .ToList();

        }
        public Employee GetEmployeeById(string employeeId)
        {
            return repositoryWrapper.Employee.FindByCondition(employee => employee.EmployeeId.Equals(employeeId))
           .FirstOrDefault();
        }

        public void AddEmployee(Employee employee)
        {

            repositoryWrapper.Employee.Create(employee);
            repositoryWrapper.Save();
        }
        public void EditEmployee(Employee employee)
        {

            repositoryWrapper.Employee.Update(employee);
            repositoryWrapper.Save();
        }
        public void DeleteEmployee(Employee employee)
        {

            repositoryWrapper.Employee.Delete(employee);
            repositoryWrapper.Save();
        }

    }
}
