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
        public byte[]? ProfilePicture { get; set; }
        public string? PasswordHash { get; set; }
        public OAuthProviderType? OAuthProvider { get; set; }
        public string? OAuthId { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
