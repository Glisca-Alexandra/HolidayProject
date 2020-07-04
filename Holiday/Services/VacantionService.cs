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
    public class VacantionService:IVacantion
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly HolidayContext _holidayContext;
        public VacantionService(IRepositoryWrapper vacantion, HolidayContext holidayContext)
        {
            repositoryWrapper = vacantion;
            _holidayContext = holidayContext;

        }
        public IEnumerable<Vacantion> GetAllVacantions()
        {
            return repositoryWrapper.Vacantion.FindAll()
                .OrderBy(tl => tl.VacantionType)
                .ToList();

        }
        public Vacantion GetVacantionById(string VacantionId)
        {
            return repositoryWrapper.Vacantion.FindByCondition(vacantion => vacantion.VacantionId.Equals(VacantionId))
           .FirstOrDefault();
        }

        public void CreateVacantion(Vacantion vacantion)
        {

            repositoryWrapper.Vacantion.Create(vacantion);
            repositoryWrapper.Save();
        }
        public void EditVacantion(Vacantion vacantion)
        {

            repositoryWrapper.Vacantion.Update(vacantion);
            repositoryWrapper.Save();
        }
        public void DeleteVacantion(Vacantion vacantion)
        {

            repositoryWrapper.Vacantion.Delete(vacantion);
            repositoryWrapper.Save();
        }

    }
}
