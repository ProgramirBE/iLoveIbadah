using DhikrCount.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.DTOs.UserDhikrCount
{
    public class UserDhikrCountDto : BaseDto
    {
        public int UserAccountId { get; set; }
        public int DhikrTypeId { get; set; }
        public int TotalPerformed { get; set; }
    }
}
