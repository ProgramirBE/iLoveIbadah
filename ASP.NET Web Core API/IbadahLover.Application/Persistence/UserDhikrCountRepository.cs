using IbadahLover.Application.Persistence.Contracts;
using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Persistence
{
    public class UserDhikrCountRepository : IGenericRepository<UserDhikrCount>, IUserDhikrCountRepository
    {
        public Task<UserDhikrCount> Create(UserDhikrCount entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserDhikrCount> Delete(UserDhikrCount entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<UserDhikrCount>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDhikrCount> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDhikrCount>> GetUserDhikrCountsWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<UserDhikrCount> GetUserDhikrCountWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDhikrCount> Update(UserDhikrCount entity)
        {
            throw new NotImplementedException();

            //var userDhikrCount = await _dbContext.UserDhikrCounts.FindAsync(entity.UserAccountId, entity.DhikrTypeId); //il y a un s à la fin de userdhikrcount(s)
            //userDhikrCount.TotalPerformed += 1;
            //await _dbContext.SaveChangesAsync();
        }

        //private readonly DbContext _dbContext;

        //public UserDhikrCountRepository(DbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public async Task UpdateDhikrCount(int UserAccountId, int DhikrTypeId)
        //{
        //    //var userDhikrCount = await _dbContext.UserDhikrCounts.FindAsync(UserAccountId, DhikrTypeId);
        //    //userDhikrCount.TotalPerformed += 1;
        //    //await _dbContext.SaveChangesAsync();
        //}
    }
}
