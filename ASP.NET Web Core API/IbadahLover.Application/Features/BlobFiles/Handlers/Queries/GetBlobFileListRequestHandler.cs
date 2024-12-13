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
    public class GetBlobFileListRequestHandler : IRequestHandler<GetBlobFileListRequest, List<BlobFileListDto>>
    {
        private readonly IBlobFileRepository _blobFileRepository;
        private readonly IMapper _mapper;

        public GetBlobFileListRequestHandler(IBlobFileRepository blobFileRepository, IMapper mapper)
        {
            _blobFileRepository = blobFileRepository;
            _mapper = mapper;
        }
        public async Task<List<BlobFileListDto>> Handle(GetBlobFileListRequest request, CancellationToken cancellationToken)
        {
            var blobFiles = await _blobFileRepository.GetAll();
            return _mapper.Map<List<BlobFileListDto>>(blobFiles);
        }
    }
}
