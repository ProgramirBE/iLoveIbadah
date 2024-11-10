using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Persistence.Contracts
{
    // Repository of All SQL Methods for UserDhikrCount Entity
    public interface IUserDhikrCountRepository : IGenericRepository<UserDhikrCount>
    {
        Task<UserDhikrCount> GetUserDhikrCountWithDetails(int id);
        Task<List<UserDhikrCount>> GetUserDhikrCountsWithDetails();
        Task UpdateDhikrCount(UserDhikrCount userDhikrCount);
    }
}
