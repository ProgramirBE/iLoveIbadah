//using IbadahLover.Domain.Common;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace IbadahLover.Domain
//{
//    public class UserAccountBanType
//    {
//        [ForeignKey("UserAccount")]
//        public int UserAccountId { get; set; }
//        public UserAccount UserAccount { get; set; } // Navigation property
//        [ForeignKey("BanType")]
//        public int BanTypeId { get; set; }
//        public BanType BanType { get; set; } // Navigation property
//        [DataType(DataType.Date)]
//        public DateTime BannedOn { get; set; }
//        [ForeignKey("BannedByUserAccount")]
//        public int BannedBy { get; set; }
//        public UserAccount BannedByUserAccount { get; set; } // Navigation property
//        [DataType(DataType.Date)]
//        public DateTime LastModifiedOn { get; set; }
//        [ForeignKey("LastModifiedByUserAccount")]
//        public int LastModifiedBy { get; set; }
//        public UserAccount LastModifiedByUserAccount { get; set; } // Navigation property
//    }
//}


// Because I realized it is a 1 on Many relationship, I Will just add a BanType property to the UserAccount class 🤦‍♂