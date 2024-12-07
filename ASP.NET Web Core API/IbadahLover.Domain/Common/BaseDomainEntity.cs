using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain.Common
{

    //no more basedomainentity because these logging information will be stored in azure blob storage instead of database

    //For All Database Tables 
    //public class BaseDomainEntity
    //{
    //    public int Id { get; set; }
    //    [DataType(DataType.Date)]
    //    public DateTime CreatedOn { get; set; }
    //    [ForeignKey("CreatedByUserAccount")]
    //    public int CreatedBy { get; set; }
    //    public UserAccount CreatedByUserAccount { get; set; }
    //    [DataType(DataType.Date)]
    //    public DateTime LastModifiedOn { get; set; }
    //    [ForeignKey("LastModifiedByUserAccount")]
    //    public int? LastModifiedBy { get; set; }
    //    public UserAccount? LastModifiedByUserAccount { get; set; }
    //}
}
