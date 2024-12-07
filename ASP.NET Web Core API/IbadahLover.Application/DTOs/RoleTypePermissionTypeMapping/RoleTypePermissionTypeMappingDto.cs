using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.RoleTypePermissionTypeMapping
{
    public class RoleTypePermissionTypeMappingDto
    {
        public int Id { get; set; }
        public int RoleTypeId { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
