using IbadahLover.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserDhikrOverview
{
    public class UpdateUserDhikrOverviewDto
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int TotalPerformed { get; set; }
        public DateTime LastPerformedAt { get; set; }
    }
}
