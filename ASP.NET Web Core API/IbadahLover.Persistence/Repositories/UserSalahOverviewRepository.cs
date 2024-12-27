using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Persistence.Repositories
{
    public class UserSalahOverviewRepository : GenericRepository<UserSalahOverview>, IUserSalahOverviewRepository
    {
        private readonly IbadahLoverDbContext _dbContext;
        public UserSalahOverviewRepository(IbadahLoverDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserSalahOverview>> GetUserSalahOverviewsWithDetails()
        {
            var userSalahOverviews = await _dbContext.UserSalahOverviews
                .Include(q => q.UserAccount)
                .ToListAsync();
            return userSalahOverviews;
        }

        public async Task<UserSalahOverview> GetUserSalahOverviewWithDetails(int id)
        {
            var userSalahOverview = await _dbContext.UserSalahOverviews
                .Include(q => q.UserAccount)
                .FirstOrDefaultAsync(q => q.Id == id);
            return userSalahOverview;
        }

        public async Task<UserSalahOverview> GetUserSalahOverviewByUserAccountWithDetails(int userAccountId)
        {
            var userSalahOverview = await _dbContext.UserSalahOverviews
                .Include(q => q.UserAccount)
                .FirstOrDefaultAsync(q => q.UserAccountId == userAccountId);
            return userSalahOverview;
        }
    }
}
