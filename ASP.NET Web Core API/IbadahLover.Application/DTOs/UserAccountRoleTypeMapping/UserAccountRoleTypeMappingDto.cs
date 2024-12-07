using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccountRoleTypeMapping
{
    public class UserAccountRoleTypeMappingDto
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int RoleTypeId { get; set; }
    }
}
