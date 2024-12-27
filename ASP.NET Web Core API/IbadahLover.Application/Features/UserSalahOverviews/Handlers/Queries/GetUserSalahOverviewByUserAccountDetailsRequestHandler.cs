using AutoMapper;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.DTOs.UserSalahOverview;
using IbadahLover.Application.Features.UserSalahOverviews.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserSalahOverviews.Handlers.Queries
{
    public class GetUserSalahOverviewByUserAccountDetailsRequestHandler : IRequestHandler<GetUserSalahOverviewByUserAccountDetailsRequest, UserSalahOverviewDto>
    {
        private readonly IUserSalahOverviewRepository _userSalahOverviewRepository;
        private readonly IMapper _mapper;

        public GetUserSalahOverviewByUserAccountDetailsRequestHandler(IUserSalahOverviewRepository userSalahOverviewRepository, IMapper mapper)
        {
            _userSalahOverviewRepository = userSalahOverviewRepository;
            _mapper = mapper;
        }
        public async Task<UserSalahOverviewDto> Handle(GetUserSalahOverviewByUserAccountDetailsRequest request, CancellationToken cancellationToken)
        {
            var userSalahOverview = await _userSalahOverviewRepository.GetUserSalahOverviewByUserAccountWithDetails(request.UserAccountId);
            return _mapper.Map<UserSalahOverviewDto>(userSalahOverview);
        }
    }
}
