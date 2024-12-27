using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.Features.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserAccounts.Requests.Queries
{
    // Application User Request to get Details of User Account
    public class GetUserAccountDetailsRequest : IRequest<UserAccountDto>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UniqueId { get; set; }
        //public string? NormalizedUniqueId { get; set; }
        public string Email { get; set; }
        //public string? NormalizedEmail { get; set; }
        public int? ProfilePicture { get; set; }
        //public string? PasswordHash { get; set; }
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
        //public string? SecurityStamp { get; set; }
        //public string? ConcurrencyStamp { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public DateTime LastModifiedOn { get; set; }
        //public int LastModifiedBy { get; set; }
    }
}
