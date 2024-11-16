using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class UserDhikrOverview
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int TotalPerformed { get; set; }
        public DateTime LastPerformedAt { get; set; }
    }
}
