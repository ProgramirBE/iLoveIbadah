using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Contracts.Persistence
{
    public interface IUserAccountRoleTypeMappingRepository : IGenericRepository<UserAccountRoleTypeMapping>
    {
        Task<UserAccountRoleTypeMapping> GetUserAccountRoleTypeMappingWithDetails(int id);
        Task<List<UserAccountRoleTypeMapping>> GetUserAccountRoleTypeMappingsWithDetails();
        //Task<UserAccountRoleTypeMapping> GetUserAccountRoleTypeMappingByUserAccountAndRoleType(int userAccountId, int roleTypeId);
        //Task<List<UserAccountRoleTypeMapping>> GetUserAccountRoleTypeMappingsByUserAccount(int UserAccountId);
        //Task<List<UserAccountRoleTypeMapping>> GetUserAccountRoleTypeMappingsByRoleType(int roleTypeId);
    }
}
