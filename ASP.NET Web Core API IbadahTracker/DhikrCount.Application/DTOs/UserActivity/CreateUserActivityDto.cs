using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.DTOs.UserActivity
{
    public class CreateUserActivityDto
    {
        public int UserAccountId { get; set; }

        public int DhikrTypeId { get; set; }
        public int TotalDhikrPerformed { get; set; }
    }
}
