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
    public class VacantionRequestService:IVacantionRequest
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly HolidayContext _holidayContext;
        public VacantionRequestService(IRepositoryWrapper vacantionRequest, HolidayContext holidayContext)
        {
            repositoryWrapper = vacantionRequest;
            _holidayContext = holidayContext;

        }
        public IEnumerable<VacantionRequest> GetAllVacantionRequests()
        {
            return repositoryWrapper.VacantionRequest.FindAll()
                .OrderBy(tl => tl.Type)
                .ToList();

        }
        public VacantionRequest GetVacantionRequestById(string VacantionRequestId)
        {
            return repositoryWrapper.VacantionRequest.FindByCondition(vacantionRequest => vacantionRequest.VacantionRequestId.Equals(VacantionRequestId))
           .FirstOrDefault();
        }
        public void CreateVacantionRequest(VacantionRequest vacantionRequest)
        {

            repositoryWrapper.VacantionRequest.Create(vacantionRequest);
            repositoryWrapper.Save();
        }
    }
}
