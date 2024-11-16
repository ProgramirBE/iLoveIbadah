using IbadahLover.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserDhikrActivity
{
    public class UserDhikrActivityDto : BaseDto
    {
        public int UserAccountId { get; set; }

        public int DhikrTypeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime PerformedAt { get; set; }
        public int TotalDhikrPerformed { get; set; }
    }
}
