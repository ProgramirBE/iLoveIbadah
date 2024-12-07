using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Persistence.Contracts
{
    public interface IRoleTypePermissionTypeRepository : IGenericRepository<RoleTypePermissionTypeMapping>
    {
        Task<RoleTypePermissionTypeMapping> GetRoleTypePermissionTypeWithDetails(int id);
        Task<List<RoleTypePermissionTypeMapping>> GetRoleTypePermissionTypesWithDetails();
    }
}
