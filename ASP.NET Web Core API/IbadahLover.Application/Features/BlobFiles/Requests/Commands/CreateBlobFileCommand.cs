using IbadahLover.Application.DTOs.BlobFile;
using IbadahLover.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.BlobFiles.Requests.Commands
{
    public class CreateBlobFileCommand : IRequest<BaseCommandResponse>
    {
        public CreateBlobFileDto BlobFileDto { get; set; }
    }
}
