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
    public class RoleTypeRepository : GenericRepository<RoleType>, IRoleTypeRepository
    {
        private readonly IbadahLoverDbContext _dbContext;
        public RoleTypeRepository(IbadahLoverDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RoleType>> GetRoleTypesWithDetails()
        {
            var roleTypes = await _dbContext.RoleTypes
                .ToListAsync();
            return roleTypes;
        }

        public async Task<RoleType> GetRoleTypeWithDetails(int id)
        {
            var roleType = await _dbContext.RoleTypes
                .FirstOrDefaultAsync(q => q.Id == id);
            return roleType;
        }
    }
}
