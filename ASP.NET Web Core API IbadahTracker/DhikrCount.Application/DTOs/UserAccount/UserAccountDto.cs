using DhikrCount.Application.DTOs.Common;
using DhikrCount.Application.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.DTOs.UserAccount
{
    public class UserAccountDto : BaseDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public OAuthProviderType? OAuthProvider { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
