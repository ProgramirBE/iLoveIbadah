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
    public class UserAccountRoleTypeMappingRepository : GenericRepository<UserAccountRoleTypeMapping>, IUserAccountRoleTypeMappingRepository
    {
        private readonly IbadahLoverDbContext _dbContext;
        public UserAccountRoleTypeMappingRepository(IbadahLoverDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserAccountRoleTypeMapping>> GetUserAccountRoleTypeMappingsWithDetails()
        {
            var userAccountRoleTypeMappings = await _dbContext.UserAccountRoleTypeMappings
                .Include(p => p.UserAccount)
                .Include(p => p.RoleType)
                .ToListAsync();
            return userAccountRoleTypeMappings;
        }

        public async Task<UserAccountRoleTypeMapping> GetUserAccountRoleTypeMappingWithDetails(int id)
        {
            var userAccountRoleTypeMapping = await _dbContext.UserAccountRoleTypeMappings
                .Include(p => p.UserAccount)
                .Include(p => p.RoleType)
                .FirstOrDefaultAsync(p => p.Id == id);
            return userAccountRoleTypeMapping;
        }
    }
}
