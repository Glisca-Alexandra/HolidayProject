using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IVacantionRepository Vacantion { get; }

        IEmployeeRepository Employee { get; }

        IVacantionRequestRepository VacantionRequest { get; }

        void Save();
    }
}
