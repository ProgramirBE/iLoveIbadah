using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserSalahOverview
{
    public class UpdateUserSalahOverviewDto
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int TotalTracked { get; set; }
        public DateTime LastTrackedAt { get; set; }
    }
}
