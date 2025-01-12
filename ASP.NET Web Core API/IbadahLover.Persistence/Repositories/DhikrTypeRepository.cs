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
    public class DhikrTypeRepository : GenericRepository<DhikrType>, IDhikrTypeRepository
    {
        private readonly IbadahLoverDbContext _dbContext;
        public DhikrTypeRepository(IbadahLoverDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DhikrType>> GetDhikrTypesWithDetails()
        {
            var dhikrTypes = await _dbContext.DhikrTypes
                .ToListAsync();
            return dhikrTypes;
        }

        public async Task<DhikrType> GetDhikrTypeWithDetails(int id)
        {
            var dhikrType = await _dbContext.DhikrTypes
                .FirstOrDefaultAsync(Queryable => Queryable.Id == id);
            return dhikrType;
        }

        public async Task<List<DhikrType>> GetDhikrTypesByUserAccountId(int userAccountId)
        {
            var dhikrTypes = await _dbContext.DhikrTypes
                .Where(q => q.CreatedBy == userAccountId)
                .ToListAsync();
            return dhikrTypes;
        }
    }
}
