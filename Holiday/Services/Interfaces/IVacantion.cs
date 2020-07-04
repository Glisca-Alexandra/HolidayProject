using Holiday.Models;
using Holiday.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday.Services.Interfaces
{
    public interface IVacantion
    {
        IEnumerable<Vacantion> GetAllVacantions();
     
        Vacantion GetVacantionById(string vacantionId);
        void CreateVacantion(Vacantion vacantion);
        void EditVacantion(Vacantion vacantion);

        void DeleteVacantion(Vacantion vacantion);
    }
}
