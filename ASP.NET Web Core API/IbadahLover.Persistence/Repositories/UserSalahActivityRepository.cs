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
    public class UserSalahActivityRepository : GenericRepository<UserSalahActivity>, IUserSalahActivityRepository
    {
        private readonly IbadahLoverDbContext _dbContext;
        public UserSalahActivityRepository(IbadahLoverDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserSalahActivity>> GetUserSalahActivitiesWithDetails()
        {
            var userSalahActivities = await _dbContext.UserSalahActivities
                .Include(q => q.UserAccount)
                .Include(q => q.SalahType)
                .ToListAsync();
            return userSalahActivities;
        }

        public async Task<UserSalahActivity> GetUserSalahActivityWithDetails(int id)
        {
            var userSalahActivity = await _dbContext.UserSalahActivities
                .Include(q => q.UserAccount)
                .Include(q => q.SalahType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return userSalahActivity;
        }

        public async Task<UserSalahActivity> GetUserSalahActivityByTrackedOn(int userAccountId, DateTime trackedOn, int salahTypeId)
        {
            var userSalahActivity = await _dbContext.UserSalahActivities
                .Include(q => q.UserAccount)
                .Include(q => q.SalahType)
                .FirstOrDefaultAsync(q => q.UserAccountId == userAccountId && q.TrackedOn.Date == trackedOn.Date && q.SalahTypeId == salahTypeId); //trackedOn.Date requires additional processing, table and class both already store date in yyyy-mm-dd so no need for trackedOn.Date to check to day precision only
            return userSalahActivity;
        }

        public async Task<List<UserSalahActivity>> GetUserSalahActivitiesByTrackedOn(int userAccountId, DateTime trackedOn)
        {
            var userSalahActivities = await _dbContext.UserSalahActivities
                .Include(q => q.UserAccount)
                .Include(q => q.SalahType)
                .Where(q => q.UserAccountId == userAccountId && q.TrackedOn.Date == trackedOn.Date)
                .ToListAsync();
            return userSalahActivities;
        }

        public async Task<bool> TrackedOnExists(int userAccountId, DateTime trackedOn, int salahTypeId)
        {
            var userSalahActivity = await _dbContext.UserSalahActivities
                .Include(q => q.UserAccount)
                .Include(q => q.SalahType)
                .FirstOrDefaultAsync(q => q.UserAccountId == userAccountId && q.TrackedOn.Date == trackedOn.Date && q.SalahTypeId == salahTypeId); //trackedOn.Date requires additional processing, table and class both already store date in yyyy-mm-dd so no need for trackedOn.Date to check to day precision only
            return userSalahActivity != null;
        }
    }
}
