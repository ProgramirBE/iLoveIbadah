using IbadahLover.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    //Database Table DhikrType
    public class SalahType
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [ForeignKey("UserAccount")]
        public int CreatedBy { get; set; }
        public UserAccount UserAccount { get; set; } // Navigation property
    }
}
