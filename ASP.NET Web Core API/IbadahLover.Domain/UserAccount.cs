using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UniqueId { get; set; }
        public string? NormalizedUniqueId { get; set; }
        public string Email { get; set; }
        public string? NormalizedEmail { get; set; }
        [ForeignKey("ProfilePictureType")]
        public int? ProfilePictureTypeId { get; set; }
        public ProfilePictureType? ProfilePictureType { get; set; }
        public string? PasswordHash { get; set; }
        //public OAuthProviderType? OAuthProvider { get; set; }
        //public string? OAuthId { get; set; }
        //[Column(TypeName = "decimal(11, 8)")]
        //public decimal? CurrentLongitude { get; set; }
        //[Column(TypeName = "decimal(10, 8)")]
        //public decimal? CurrentLatitude { get; set; }
        public string? CurrentLocation { get; set; }
        public int? TotalWarnings { get; set; }
        public bool? EmailConfirmed { get; set; }
        public bool? IsPermanentlyBanned { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime CreatedOn { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime LastModifiedOn { get; set; }
        //[ForeignKey("LastModifiedByUserAccount")]
        //public int? LastModifiedBy { get; set; }
        //public UserAccount? LastModifiedByUserAccount { get; set; } // Navigation property
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }
}
