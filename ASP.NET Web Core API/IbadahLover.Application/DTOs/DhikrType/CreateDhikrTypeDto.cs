using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.DhikrType
{
    public class CreateDhikrTypeDto
    {
        public string FullName { get; set; }
        public int? CreatedBy { get; set; }
        public string? ArabicFullName { get; set; }
    }
}
