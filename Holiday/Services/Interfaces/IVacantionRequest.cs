using Holiday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday.Services.Interfaces
{
    public interface IVacantionRequest
    {
        IEnumerable<VacantionRequest> GetAllVacantionRequests();

        VacantionRequest GetVacantionRequestById(string vacantionRequestId);
        void CreateVacantionRequest(VacantionRequest vacantionRequest);
        //void EditVacantion(Vacantion vacantion);

        //void DeleteVacantion(Vacantion vacantion);
    }
}
