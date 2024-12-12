using AutoMapper;
using IbadahLover.Application.DTOs.UserSalahActivity;
using IbadahLover.Application.Features.UserSalahActivities.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserSalahActivities.Handlers.Queries
{
    public class GetUserSalahActivityDetailsRequestHandler : IRequestHandler<GetUserSalahActivityDetailsRequest, UserSalahActivityDto>
    {
        private readonly IUserSalahActivityRepository _userSalahActivityRepository;
        private readonly IMapper _mapper;

        public GetUserSalahActivityDetailsRequestHandler(IUserSalahActivityRepository userSalahActivityRepository, IMapper mapper)
        {
            _userSalahActivityRepository = userSalahActivityRepository;
            _mapper = mapper;
        }
        public async Task<UserSalahActivityDto> Handle(GetUserSalahActivityDetailsRequest request, CancellationToken cancellationToken)
        {
            var userSalahActivity = await _userSalahActivityRepository.GetById(request.Id);
            return _mapper.Map<UserSalahActivityDto>(userSalahActivity);
        }
    }
}
