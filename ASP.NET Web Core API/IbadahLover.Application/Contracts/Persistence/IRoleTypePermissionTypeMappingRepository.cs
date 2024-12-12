using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Contracts.Persistence
{

    public interface IRoleTypePermissionTypeMappingRepository : IGenericRepository<RoleTypePermissionTypeMapping>
    {
        Task<RoleTypePermissionTypeMapping> GetRoleTypePermissionTypeMappingWithDetails(int id);
        Task<List<RoleTypePermissionTypeMapping>> GetRoleTypePermissionTypeMappingsWithDetails();
        //Task<RoleTypePermissionTypeMapping> GetRoleTypePermissionTypeMappingByRoleTypeAndPermissionType(int roleTypeId, int permissionTypeId);
        //Task<List<RoleTypePermissionTypeMapping>> GetRoleTypePermissionTypeMappingsByRoleType(int roleTypeId);
        //Task<List<RoleTypePermissionTypeMapping>> GetRoleTypePermissionTypeMappingsByPermissionType(int permissionTypeId);
    }
}
