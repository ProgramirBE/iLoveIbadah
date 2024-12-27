using AutoMapper;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.Features.UserSalahActivities.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserSalahActivities.Handlers.Queries
{
    public class CheckUserSalahActivityPerformedOnExistsRequestHandler : IRequestHandler<CheckUserSalahActivityPerformedOnExistsRequest, bool>
    {
        private readonly IUserSalahActivityRepository _userSalahActivityRepository;
        private readonly IMapper _mapper;

        public CheckUserSalahActivityPerformedOnExistsRequestHandler(IUserSalahActivityRepository userSalahActivityRepository, IMapper mapper)
        {
            _userSalahActivityRepository = userSalahActivityRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CheckUserSalahActivityPerformedOnExistsRequest request, CancellationToken cancellationToken)
        {
            var userSalahActivityPerformedOnExists = await _userSalahActivityRepository.TrackedOnExists(request.UserAccountId.Value, request.TrackedOn, request.SalahTypeId);
            return userSalahActivityPerformedOnExists;
        }
    }
}
