using DhikrCount.Application.DTOs.Common;
using DhikrCount.Application.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.DTOs.UserAccount
{
    public class CreateUserAccountDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? PasswordHash { get; set; }
        public OAuthProviderType? OAuthProvider { get; set; }
        public string? OAuthId { get; set; }
    }
}
