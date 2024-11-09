using DhikrCount.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.Persistence.Contracts
{
    // Repository of All SQL Methods for DhikrType Entity
    public interface IDhikrTypeRepository : IGenericRepository<DhikrType>
    {
        Task<DhikrType> GetDhikrTypeWithDetails(int id);
        Task<List<UserAccount>> GetDhikrTypesWithDetails();
    }
}
