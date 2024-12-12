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
    public class ProfilePictureTypeRepository : GenericRepository<ProfilePictureType>, IProfilePictureTypeRepository
    {
        private readonly IbadahLoverDbContext _dbContext;
        public ProfilePictureTypeRepository(IbadahLoverDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProfilePictureType>> GetProfilePictureTypesWithDetails()
        {
            var profilePictureTypes = await _dbContext.ProfilePictureTypes
                .ToListAsync();
            return profilePictureTypes;
        }

        public async Task<ProfilePictureType> GetProfilePictureTypeWithDetails(int id)
        {
            var profilePictureType = await _dbContext.ProfilePictureTypes
                .FirstOrDefaultAsync(q => q.Id == id);
            return profilePictureType;
        }
    }
}
