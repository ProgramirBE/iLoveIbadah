using IbadahLover.Application.DTOs.Common;
using IbadahLover.Application.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount
{
    public class UserAccountDto
    {
        public int Id { get; set; } //already passed in the url??? I don't know if i should keep it......
        public string FullName { get; set; }
        public string UniqueId { get; set; }
        public string Email { get; set; }
        //public string? NormalizedEmail { get; set; }
        //public string? NormalizedUniqueId { get; set; }
        public int? ProfilePictureTypeId { get; set; }
        //public OAuthProviderType? OAuthProvider { get; set; }
        //[Column(TypeName = "decimal(11, 8)")]
        //public decimal? CurrentLongitude { get; set; }
        //[Column(TypeName = "decimal(10, 8)")]
        //public decimal? CurrentLatitude { get; set; }
        public string? CurrentLocation { get; set; }
        public int? TotalWarnings { get; set; }
        public bool? EmailConfirmed { get; set; }
        public bool? IsPermanentlyBanned { get; set; }
        //public string? SecurityStamp { get; set; }
        //public string? ConcurrencyStamp { get; set; }
    }
}
