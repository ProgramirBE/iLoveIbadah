using AutoMapper;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.DTOs.BlobFile;
using IbadahLover.Application.Features.BlobFiles.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.BlobFiles.Handlers.Queries
{
    public class GetBlobFileDetailsRequestHandler : IRequestHandler<GetBlobFileDetailsRequest, BlobFileDto>
    {
        private readonly IBlobFileRepository _blobFileRepository;
        private readonly IMapper _mapper;

        public GetBlobFileDetailsRequestHandler(IBlobFileRepository blobFileRepository, IMapper mapper)
        {
            _blobFileRepository = blobFileRepository;
            _mapper = mapper;
        }
        public async Task<BlobFileDto> Handle(GetBlobFileDetailsRequest request, CancellationToken cancellationToken)
        {
            var blobFile = await _blobFileRepository.GetById(request.Id);
            return _mapper.Map<BlobFileDto>(blobFile);
        }
    }
}
