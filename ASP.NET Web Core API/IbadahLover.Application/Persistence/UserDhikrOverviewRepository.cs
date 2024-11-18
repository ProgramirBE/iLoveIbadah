using IbadahLover.Application.Persistence.Contracts;
using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Persistence
{
    public class UserDhikrOverviewRepository : IGenericRepository<UserDhikrOverview>, IUserDhikrOverviewRepository
    {
        public Task<UserDhikrOverview> Create(UserDhikrOverview entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserDhikrOverview> Delete(UserDhikrOverview entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<UserDhikrOverview>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDhikrOverview> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDhikrOverview> GetUserDhikrOverviewWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDhikrOverview>> GetUserDhikrOverviewsWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<UserDhikrOverview> Update(UserDhikrOverview entity)
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
