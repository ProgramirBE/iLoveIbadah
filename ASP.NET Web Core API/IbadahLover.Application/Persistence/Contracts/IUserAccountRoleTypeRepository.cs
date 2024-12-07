using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Persistence.Contracts
{
    public interface IUserAccountRoleTypeRepository : IGenericRepository<UserAccountRoleTypeMapping>
    {
        Task<UserAccountRoleTypeMapping> GetUserAccountRoleTypeWithDetails(int id);
        Task<List<UserAccountRoleTypeMapping>> GetUserAccountRoleTypesWithDetails();
    }
}
