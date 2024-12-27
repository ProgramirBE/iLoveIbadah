using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserDhikrActivity
{
    public class UserDhikrActivityByPerformedOnDto
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int DhikrTypeId { get; set; }
        public DateTime PerformedOn { get; set; }
        public DateTime LastPerformedAt { get; set; }
        public int TotalPerformed { get; set; }
    }
}
