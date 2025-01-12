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
    public class DhikrType
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? ArabicFullName { get; set; }
        [ForeignKey("CreatedByUserAccount")]
        public int CreatedBy { get; set; }
        public UserAccount CreatedByUserAccount { get; set; } // Navigation property
    }
}
