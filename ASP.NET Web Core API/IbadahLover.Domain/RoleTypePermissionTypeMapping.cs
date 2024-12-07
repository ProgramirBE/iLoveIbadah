using IbadahLover.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class RoleTypePermissionTypeMapping
    {
        public int Id { get; set; }
        [ForeignKey("RoleType")]
        public int RoleTypeId { get; set; }
        public RoleType RoleType { get; set; } // Navigation property
        [ForeignKey("PermissionType")]
        public int PermissionTypeId { get; set; }
        public PermissionType PermissionType { get; set; } // Navigation property
    }
}
