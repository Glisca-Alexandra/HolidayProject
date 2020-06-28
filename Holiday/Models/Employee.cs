using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday.Models
{
    public class Employee
    {
        public string EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int NumberOfDays { get; set; }

        public Vacantion Vacantion { get; set; }
    }
}
