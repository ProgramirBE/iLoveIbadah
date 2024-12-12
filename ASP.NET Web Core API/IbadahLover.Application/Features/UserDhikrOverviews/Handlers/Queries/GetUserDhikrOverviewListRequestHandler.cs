using AutoMapper;
using IbadahLover.Application.DTOs.UserDhikrOverview;
using IbadahLover.Application.Features.UserDhikrOverviews.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrOverviews.Handlers.Queries
{
    public class GetUserDhikrOverviewListRequestHandler : IRequestHandler<GetUserDhikrOverviewListRequest, List<UserDhikrOverviewListDto>>
    {
        private readonly IUserDhikrOverviewRepository _userDhikrOverviewRepository;
        private readonly IMapper _mapper;

        public GetUserDhikrOverviewListRequestHandler(IUserDhikrOverviewRepository userDhikrOverviewRepository, IMapper mapper)
        {
            _userDhikrOverviewRepository = userDhikrOverviewRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDhikrOverviewListDto>> Handle(GetUserDhikrOverviewListRequest request, CancellationToken cancellationToken)
        {
            var userDhikrOverview = await _userDhikrOverviewRepository.GetAll();
            return _mapper.Map<List<UserDhikrOverviewListDto>>(userDhikrOverview);
        }
    }
}
