using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class UserSalahOverview
    {
        public int Id { get; set; }
        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; } // Navigation property
        public int TotalTracked { get; set; }
        public DateTime LastTrackedAt { get; set; }
    }
}
