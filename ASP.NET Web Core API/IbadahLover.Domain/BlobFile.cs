using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class BlobFile
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public string FullName { get; set; }
        public string Extension { get; set; }
        public int? Size { get; set; }
        public int CreatedBy { get; set; }
    }
}
