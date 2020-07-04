using Holiday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday.Services.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeById(string employeeId);
        void AddEmployee(Employee employee);
        void EditEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
    }
}
