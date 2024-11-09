using AutoMapper;
using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.DTOs.UserActivity;
using IbadahLover.Application.Features.UserAccounts.Requests.Queries;
using IbadahLover.Application.Features.UserActivities.Requests.Queries;
using IbadahLover.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserActivities.Handlers.Queries
{
    // Backend Handler of Request to get Details of User Activity
    public class GetUserActivityDetailsRequestHandler : IRequestHandler<GetUserActivityDetailsRequest, UserActivityDto>
    {
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly IMapper _mapper;

        public GetUserActivityDetailsRequestHandler(IUserActivityRepository userActivityRepository, IMapper mapper)
        {
            _userActivityRepository = userActivityRepository;
            _mapper = mapper;
        }
        public async Task<UserActivityDto> Handle(GetUserActivityDetailsRequest request, CancellationToken cancellationToken)
        {
            var userActivity = await _userActivityRepository.GetById(request.Id);
            return _mapper.Map<UserActivityDto>(userActivity);
        }
    }
}
