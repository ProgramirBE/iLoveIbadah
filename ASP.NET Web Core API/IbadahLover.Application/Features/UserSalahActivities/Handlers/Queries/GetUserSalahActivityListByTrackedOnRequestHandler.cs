using AutoMapper;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.DTOs.UserSalahActivity;
using IbadahLover.Application.Features.UserSalahActivities.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserSalahActivities.Handlers.Queries
{
    internal class GetUserSalahActivityListByTrackedOnRequestHandler : IRequestHandler<GetUserSalahActivityListByTrackedOnRequest, List<UserSalahActivityListByTrackedOnDto>>
    {
        private readonly IUserSalahActivityRepository _userSalahActivityRepository;
        private readonly IMapper _mapper;

        public GetUserSalahActivityListByTrackedOnRequestHandler(IUserSalahActivityRepository userSalahActivityRepository, IMapper mapper)
        {
            _userSalahActivityRepository = userSalahActivityRepository;
            _mapper = mapper;
        }
        public async Task<List<UserSalahActivityListByTrackedOnDto>> Handle(GetUserSalahActivityListByTrackedOnRequest request, CancellationToken cancellationToken)
        {
            var userSalahActivity = await _userSalahActivityRepository.GetUserSalahActivitiesByTrackedOn(request.UserAccountId, request.TrackedOn);
            return _mapper.Map<List<UserSalahActivityListByTrackedOnDto>>(userSalahActivity);
        }
    }
}
