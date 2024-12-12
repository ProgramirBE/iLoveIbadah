using AutoMapper;
using IbadahLover.Application.DTOs.UserDhikrOverview;
using IbadahLover.Application.Features.UserDhikrOverviews.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrOverviews.Handlers.Queries
{
    //public class GetUserDhikrOverviewDetailsRequestHandler IRequestHandler<GetUserDhikrActivityDetailsRequest, UserDhikrActivityDto>
    public class GetUserDhikrOverviewDetailsRequestHandler : IRequestHandler<GetUserDhikrOverviewDetailsRequest, UserDhikrOverviewDto>
    {
        private readonly IUserDhikrOverviewRepository _userDhikrOverviewRepository;
        private readonly IMapper _mapper;

        public GetUserDhikrOverviewDetailsRequestHandler(IUserDhikrOverviewRepository userDhikrOverviewRepository, IMapper mapper)
        {
            _userDhikrOverviewRepository = userDhikrOverviewRepository;
            _mapper = mapper;
        }
        public async Task<UserDhikrOverviewDto> Handle(GetUserDhikrOverviewDetailsRequest request, CancellationToken cancellationToken)
        {
            var userDhikrOverview = await _userDhikrOverviewRepository.GetById(request.Id);
            return _mapper.Map<UserDhikrOverviewDto>(userDhikrOverview);
        }
    }
}
