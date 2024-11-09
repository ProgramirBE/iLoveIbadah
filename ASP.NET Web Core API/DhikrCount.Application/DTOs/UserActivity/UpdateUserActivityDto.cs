using DhikrCount.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.DTOs.UserActivity
{
    public class UpdateUserActivityDto : BaseDto
    {
        public int TotalDhikrPerformed { get; set; }
    }
}