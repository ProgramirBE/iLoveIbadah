using IbadahLover.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.ProfilePictureType
{
    public class ProfilePictureTypeListDto
    {
        public int Id { get; set; }
        public int BlobFileId { get; set; }
        public int CreatedBy { get; set; }
    }
}
