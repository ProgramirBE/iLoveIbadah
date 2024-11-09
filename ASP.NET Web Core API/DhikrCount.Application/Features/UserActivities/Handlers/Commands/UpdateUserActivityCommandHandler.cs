using AutoMapper;
using DhikrCount.Application.Features.UserAccounts.Requests.Commands;
using DhikrCount.Application.Features.UserActivities.Requests.Commands;
using DhikrCount.Application.Persistence.Contracts;
using DhikrCount.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.Features.UserActivities.Handlers.Commands
{
    public class UpdateUserActivityCommandHandler : IRequestHandler<UpdateUserActivityCommand, Unit>
    {
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly IMapper _mapper;

        public UpdateUserActivityCommandHandler(IUserActivityRepository userActivityRepository, IMapper mapper)
        {
            _userActivityRepository = userActivityRepository;
            _mapper = mapper;   
        }

        public async Task<Unit> Handle(UpdateUserActivityCommand request, CancellationToken cancellationToken)
        {
            var userActivity = await _userActivityRepository.GetById(request.UserActivityDto.Id);

            _mapper.Map(request.UserActivityDto, userActivity);

            await _userActivityRepository.Update(userActivity);

            return Unit.Value;
        }
    }
}
