using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class UserAccountAuthenticationToken
    {
        public int Id { get; set; }
        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
        public string LoginProvider { get; set; }
        public string UniqueId { get; set; }
        public string JwtValue { get; set; }
        public string? JwtValueHash { get; set; } // limit to 64 characters so I can index it in db unique index! for now just nullable!
    }
}
