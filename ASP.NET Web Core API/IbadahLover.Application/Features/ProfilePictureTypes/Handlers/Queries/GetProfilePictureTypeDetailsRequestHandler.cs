using AutoMapper;
using IbadahLover.Application.DTOs.ProfilePictureType;
using IbadahLover.Application.Features.ProfilePictureTypes.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.ProfilePictureTypes.Handlers.Queries
{
    public class GetProfilePictureTypeDetailsRequestHandler : IRequestHandler<GetProfilePictureTypeDetailsRequest, ProfilePictureTypeDto>
    {
        private readonly IProfilePictureTypeRepository _profilePictureTypeRepository;
        private readonly IMapper _mapper;

        public GetProfilePictureTypeDetailsRequestHandler(IProfilePictureTypeRepository profilePictureTypeRepository, IMapper mapper)
        {
            _profilePictureTypeRepository = profilePictureTypeRepository;
            _mapper = mapper;
        }
        public async Task<ProfilePictureTypeDto> Handle(GetProfilePictureTypeDetailsRequest request, CancellationToken cancellationToken)
        {
            var profilePictureType = await _profilePictureTypeRepository.GetById(request.Id);
            return _mapper.Map<ProfilePictureTypeDto>(profilePictureType);
        }
    }
}
