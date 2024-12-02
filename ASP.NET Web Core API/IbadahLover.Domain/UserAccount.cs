using IbadahLover.Domain.Common;
using IbadahLover.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    //Database Table UserAccount
    public class UserAccount : BaseDomainEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int? ProfilePictureTypeId { get; set; }
        public string? PasswordHash { get; set; }
        public OAuthProviderType? OAuthProvider { get; set; }
        public string? OAuthId { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? CurrentLocation { get; set; }
        public int? TotalWarnings { get; set; }
    }
}
