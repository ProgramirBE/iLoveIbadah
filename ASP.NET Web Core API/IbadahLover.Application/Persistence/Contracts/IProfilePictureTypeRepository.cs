using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Persistence.Contracts
{
    public interface IProfilePictureTypeRepository : IGenericRepository<ProfilePictureType>
    {
        Task<ProfilePictureType> GetProfilePictureTypeWithDetails(int id);
        Task<List<ProfilePictureType>> GetProfilePictureTypesWithDetails();
    }
}
