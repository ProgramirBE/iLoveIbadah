using IbadahLover.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.BlobFile
{
    public class CreateBlobFileDto
    {
        public string Uri { get; set; }
        public string FullName { get; set; }
        public string Extension { get; set; }
        public int? Size { get; set; }
        public int CreatedBy { get; set; }
    }
}
