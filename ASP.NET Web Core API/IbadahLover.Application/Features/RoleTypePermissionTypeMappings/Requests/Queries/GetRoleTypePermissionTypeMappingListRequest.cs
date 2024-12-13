using IbadahLover.Application.DTOs.RoleTypePermissionTypeMapping;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.RoleTypePermissionTypeMappings.Requests.Queries
{
    public class GetRoleTypePermissionTypeMappingListRequest : IRequest<List<RoleTypePermissionTypeMappingListDto>>
    {
        public int RoleTypeId { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
