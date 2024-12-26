using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Identity.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        //public string UniqueId { get; set; } //just UserName then map to correct name...

        // Properties from IdentityUser
        [NotMapped]
        public override string? PhoneNumber { get; set; }
        [NotMapped]
        public override bool PhoneNumberConfirmed { get; set; }
        [NotMapped]
        public override bool TwoFactorEnabled { get; set; }
        [NotMapped]
        public override DateTimeOffset? LockoutEnd { get; set; }
        [NotMapped]
        public override bool LockoutEnabled { get; set; }
        [NotMapped]
        public override int AccessFailedCount { get; set; }
    }
}
