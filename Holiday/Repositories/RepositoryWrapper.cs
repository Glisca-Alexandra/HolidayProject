using Holiday.DataBaseContext;
using Holiday.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private HolidayContext _holidayContext;
        private IVacantionRepository _vacantion;
        private IEmployeeRepository _employee;
        private IVacantionRequestRepository _vacantionRequest;

        public IVacantionRepository Vacantion
        {
            get
            {
                if (_vacantion == null)
                {
                    _vacantion= new VacantionRepository(_holidayContext);
                }

                return _vacantion;
            }
        }
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_holidayContext);
                }

                return _employee;
            }
        }
     

        public IVacantionRequestRepository VacantionRequest
        {
            get
            {
                if (_vacantionRequest == null)
                {
                    _vacantionRequest = new VacantionRequestRepository(_holidayContext);
                }

                return _vacantionRequest;
            }
        }

        public RepositoryWrapper(HolidayContext holidayContext)
        {
            _holidayContext = holidayContext;
        }
        public void Save()
        {
            _holidayContext.SaveChanges();
        }
    }
}
