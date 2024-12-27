using AutoMapper;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.DTOs.UserDhikrOverview;
using IbadahLover.Application.Features.UserDhikrOverviews.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrOverviews.Handlers.Queries
{
    public class GetUserDhikrOverviewByUserAccountDetailsRequestHandler : IRequestHandler<GetUserDhikrOverviewByUserAccountDetailsRequest, UserDhikrOverviewDto>
    {
        private readonly IUserDhikrOverviewRepository _userDhikrOverviewRepository;
        private readonly IMapper _mapper;

        public GetUserDhikrOverviewByUserAccountDetailsRequestHandler(IUserDhikrOverviewRepository userDhikrOverviewRepository, IMapper mapper)
        {
            _userDhikrOverviewRepository = userDhikrOverviewRepository;
            _mapper = mapper;
        }
        public async Task<UserDhikrOverviewDto> Handle(GetUserDhikrOverviewByUserAccountDetailsRequest request, CancellationToken cancellationToken)
        {
            var userDhikrOverview = await _userDhikrOverviewRepository.GetUserDhikrOverviewByUserAccountWithDetails(request.UserAccountId);
            return _mapper.Map<UserDhikrOverviewDto>(userDhikrOverview);
        }
    }
}
