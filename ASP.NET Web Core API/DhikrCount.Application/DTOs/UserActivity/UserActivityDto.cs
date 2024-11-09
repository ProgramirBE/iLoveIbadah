using IbadahLover.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserActivity
{
    public class UserActivityDto : BaseDto
    {
        public int UserAccountId { get; set; }

        public int DhikrTypeId { get; set; }
        public DateTime PerformedAt { get; set; }
        public int TotalDhikrPerformed { get; set; }
    }
}
