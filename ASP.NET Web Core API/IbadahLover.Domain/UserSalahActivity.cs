using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class UserSalahActivity
    {
        public int Id { get; set; }
        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; } // Navigation property
        [ForeignKey("SalahType")]
        public int SalahTypeId { get; set; }
        public SalahType SalahType { get; set; } // Navigation property
        [DataType(DataType.Date)]
        public DateTime TrackedOn { get; set; }
        [Column(TypeName = "decimal(4, 2)")]
        public decimal PunctualityPercentage { get; set; }
    }
}
