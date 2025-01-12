using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Contracts.Persistence
{
    // Repository of All SQL Methods for DhikrType Entity
    public interface IDhikrTypeRepository : IGenericRepository<DhikrType>
    {
        Task<DhikrType> GetDhikrTypeWithDetails(int id);
        Task<List<DhikrType>> GetDhikrTypesWithDetails();
        Task<List<DhikrType>> GetDhikrTypesByUserAccountId(int userAccountId);
    }
}
