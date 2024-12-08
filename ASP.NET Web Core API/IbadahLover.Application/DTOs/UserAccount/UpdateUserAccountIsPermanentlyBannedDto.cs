using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount
{
    public class UpdateUserAccountIsPermanentlyBannedDto
    {
        public int Id { get; set; }
        public bool IsPermanentlyBanned { get; set; }
    }
}
