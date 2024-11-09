using DhikrCount.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Domain
{
    //Database Table UserActivity
    public class UserActivity : BaseDomainEntity
    {
        public int UserAccountId { get; set; }

        public int DhikrTypeId { get; set; }
        public DateTime PerformedAt { get; set; }
        public int TotalDhikrPerformed { get; set; }
    }
}
