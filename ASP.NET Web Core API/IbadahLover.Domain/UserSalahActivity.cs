using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class UserSalahActivity
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int SalahTypeId { get; set; }
        public DateTime performedAt { get; set; }
        public decimal punctuality_percentage { get; set; }
    }
}
