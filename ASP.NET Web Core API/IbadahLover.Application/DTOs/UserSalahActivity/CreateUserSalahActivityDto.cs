using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserSalahActivity
{
    public class CreateUserSalahActivityDto
    {
        public int? UserAccountId { get; set; }
        public int SalahTypeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime TrackedOn { get; set; }
        public decimal PunctualityPercentage { get; set; }
    }
}
