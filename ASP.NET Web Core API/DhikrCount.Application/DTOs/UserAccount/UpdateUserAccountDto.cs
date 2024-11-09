using DhikrCount.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.DTOs.UserAccount
{
    public class UpdateUserAccountDto : BaseDto
    {
        public string? FullName { get; set; }
        public string? PasswordHash { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
