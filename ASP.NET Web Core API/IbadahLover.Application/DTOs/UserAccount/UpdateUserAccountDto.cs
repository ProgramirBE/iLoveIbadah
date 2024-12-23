using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount
{
    public class UpdateUserAccountDto
    {
        //public int Id { get; set; } //already passed in the url
        public string? FullName { get; set; }
        public int? ProfilePictureTypeId { get; set; }
    }
}
