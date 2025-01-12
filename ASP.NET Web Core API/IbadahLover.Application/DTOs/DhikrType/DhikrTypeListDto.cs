using IbadahLover.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.DhikrType
{
    public class DhikrTypeListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? ArabicFullName { get; set; }
        public int CreatedBy { get; set; }
    }
}
