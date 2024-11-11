using IbadahLover.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserDhikrCount
{
    public class UpdateUserDhikrCountDto : BaseDto
    {
        public int UserAccountId { get; set; }
        public int DhikrTypeId { get; set; }
    }
}
