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
    public class GetUserActivityListRequestHandler : IRequestHandler<GetUserActivityListRequest, List<UserActivityListDto>>
    {
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly IMapper _mapper;

        public GetUserActivityListRequestHandler(IUserActivityRepository userActivityRepository, IMapper mapper)
        {
            _userActivityRepository = userActivityRepository;
            _mapper = mapper;
        }
        public async Task<List<UserActivityListDto>> Handle(GetUserActivityListRequest request, CancellationToken cancellationToken)
        {
            var userActivity = await _userActivityRepository.GetAll();
            return _mapper.Map<List<UserActivityListDto>>(userActivity);
        }
    }
}
