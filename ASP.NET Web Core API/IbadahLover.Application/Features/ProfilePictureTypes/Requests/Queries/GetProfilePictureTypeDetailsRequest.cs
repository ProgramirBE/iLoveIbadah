using IbadahLover.Application.DTOs.ProfilePictureType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.ProfilePictureTypes.Requests.Queries
{
    public class GetProfilePictureTypeDetailsRequest : IRequest<ProfilePictureTypeDto>
    {
        public int Id { get; set; }
        public int BlobFileId { get; set; }
        //public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        //public DateTime LastModifiedOn { get; set; }
        //public int LastModifiedBy { get; set; }
    }
}
