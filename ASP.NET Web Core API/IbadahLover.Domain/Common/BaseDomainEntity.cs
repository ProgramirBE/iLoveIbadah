using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain.Common
{
    //For All Database Tables 
    public class BaseDomainEntity
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
