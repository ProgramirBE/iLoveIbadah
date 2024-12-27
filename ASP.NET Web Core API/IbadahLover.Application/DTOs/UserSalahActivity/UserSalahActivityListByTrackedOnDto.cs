using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserSalahActivity
{
    public class UserSalahActivityListByTrackedOnDto
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int SalahTypeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime TrackedOn { get; set; }
        [Column(TypeName = "decimal(4, 2)")]
        public decimal PunctualityPercentage { get; set; }
    }
}
