using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday.Models
{
    public class VacantionRequest
    {
        public string VacantionRequestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public int NoOfDays { get; set; }
        public string Cause { get; set; }
    }
}
