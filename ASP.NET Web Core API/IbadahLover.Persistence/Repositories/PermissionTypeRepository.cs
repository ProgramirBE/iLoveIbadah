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
    public class PermissionTypeRepository : GenericRepository<PermissionType>, IPermissionTypeRepository
    {
        private readonly IbadahLoverDbContext _dbContext;
        public PermissionTypeRepository(IbadahLoverDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PermissionType>> GetPermissionTypesWithDetails()
        {
            var permissionTypes = await _dbContext.PermissionTypes
                .ToListAsync();
            return permissionTypes;
        }

        public async Task<PermissionType> GetPermissionTypeWithDetails(int id)
        {
            var permissionType = await _dbContext.PermissionTypes
                .FirstOrDefaultAsync(q => q.Id == id);
            return permissionType;

        }
    }
}
