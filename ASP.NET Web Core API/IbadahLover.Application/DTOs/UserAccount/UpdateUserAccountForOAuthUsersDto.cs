using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount
{
    public class UpdateUserAccountForOAuthUsersDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
