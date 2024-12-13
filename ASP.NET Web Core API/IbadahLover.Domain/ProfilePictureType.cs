using IbadahLover.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class ProfilePictureType
    {
        public int Id { get; set; }
        [ForeignKey("BlobFile")]
        public int BlobFileId { get; set; }
        public BlobFile BlobFile { get; set; }
        public int CreatedBy { get; set; }
    }
}
