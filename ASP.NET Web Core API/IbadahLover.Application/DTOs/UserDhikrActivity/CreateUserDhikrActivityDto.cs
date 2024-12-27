using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserDhikrActivity
{
    public class CreateUserDhikrActivityDto
    {
        public int? UserAccountId { get; set; }

        public int DhikrTypeId { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime PerformedOn { get; set; }
        //public DateTime LastPerformedAt { get; set; }
        //public int TotalPerformed { get; set; }
    }
}
