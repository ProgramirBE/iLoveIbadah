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
    public class GetUserSalahActivityListRequestHandler : IRequestHandler<GetUserSalahActivityListRequest, List<UserSalahActivityListDto>>
    {
        private readonly IUserSalahActivityRepository _userSalahActivityRepository;
        private readonly IMapper _mapper;

        public GetUserSalahActivityListRequestHandler(IUserSalahActivityRepository userSalahActivityRepository, IMapper mapper)
        {
            _userSalahActivityRepository = userSalahActivityRepository;
            _mapper = mapper;
        }
        public async Task<List<UserSalahActivityListDto>> Handle(GetUserSalahActivityListRequest request, CancellationToken cancellationToken)
        {
            var userSalahActivity = await _userSalahActivityRepository.GetAll();
            return _mapper.Map<List<UserSalahActivityListDto>>(userSalahActivity);
        }
    }
}
