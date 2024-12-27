using AutoMapper;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.DTOs.UserDhikrActivity;
using IbadahLover.Application.Features.UserAccountRoleTypeMappings.Requests.Queries;
using IbadahLover.Application.Features.UserDhikrActivities.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrActivities.Handlers.Queries
{
    public class GetUserDhikrActivityByPerformedOnDetailsRequestHandler : IRequestHandler<GetUserDhikrActivityByPerformedOnDetailsRequest, UserDhikrActivityByPerformedOnDto>
    {
        private readonly IUserDhikrActivityRepository _userDhikrActivityRepository;
        private readonly IMapper _mapper;

        public GetUserDhikrActivityByPerformedOnDetailsRequestHandler(IUserDhikrActivityRepository userDhikrActivityRepository, IMapper mapper)
        {
            _userDhikrActivityRepository = userDhikrActivityRepository;
            _mapper = mapper;
        }
        public async Task<UserDhikrActivityByPerformedOnDto> Handle(GetUserDhikrActivityByPerformedOnDetailsRequest request, CancellationToken cancellationToken)
        {
            var userDhikrActivity = await _userDhikrActivityRepository.GetUserDhikrActivityByPerformedOn(request.UserAccountId, request.PerformedOn, request.DhikrTypeId);
            return _mapper.Map<UserDhikrActivityByPerformedOnDto>(userDhikrActivity);
        }
    }
}
