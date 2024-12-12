using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Contracts.Persistence
{
    // Repository of All SQL Methods for SalahType Entity
    public interface ISalahTypeRepository : IGenericRepository<SalahType>
    {
        Task<SalahType> GetSalahTypeWithDetails(int id);
        Task<List<SalahType>> GetSalahTypesWithDetails();
    }
}
