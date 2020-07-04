using Holiday.DataBaseContext;
using Holiday.Models;
using Holiday.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday.Repositories
{
    public class VacantionRequestRepository : RepositoryBase<VacantionRequest>, IVacantionRequestRepository
    {
        public VacantionRequestRepository(HolidayContext holidayContext)
            : base(holidayContext)
        {
        }
    }
}
