using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class RoleTypeClaimTypeMapping
    {
        public int Id { get; set; }
        [ForeignKey("RoleType")]
        public int RoleTypeId { get; set; }
        public RoleType RoleType { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
