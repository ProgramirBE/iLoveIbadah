using IbadahLover.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    //Database Table UserDhikrActivity
    public class UserDhikrActivity
    {
        public int Id { get; set; }
        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; } // Navigation property
        [ForeignKey("DhikrType")]
        public int DhikrTypeId { get; set; }
        public DhikrType DhikrType { get; set; } // Navigation property
        [DataType(DataType.Date)]
        public DateTime PerformedOn { get; set; }
        public DateTime LastPerformedAt { get; set; }
        public int TotalPerformed { get; set; }
    }
}
