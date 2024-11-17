using AutoMapper;
using IbadahLover.Application.Features.UserAccounts.Requests.Commands;
using IbadahLover.Application.Features.UserDhikrActivities.Requests.Commands;
using IbadahLover.Application.Persistence.Contracts;
using IbadahLover.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrActivities.Handlers.Commands
{
    public class UpdateUserDhikrActivityCommandHandler : IRequestHandler<UpdateUserDhikrActivityCommand, Unit>
    {
        private readonly IUserDhikrActivityRepository _userDhikrActivityRepository;
        private readonly IMapper _mapper;

        public UpdateUserDhikrActivityCommandHandler(IUserDhikrActivityRepository userDhikrActivityRepository, IMapper mapper)
        {
            _userDhikrActivityRepository = userDhikrActivityRepository;
            _mapper = mapper;   
        }

        public async Task<Unit> Handle(UpdateUserDhikrActivityCommand request, CancellationToken cancellationToken)
        {
            var userDhikrActivity = await _userDhikrActivityRepository.GetById(request.UserDhikrActivityDto.Id);

            _mapper.Map(request.UserDhikrActivityDto, userDhikrActivity);

            await _userDhikrActivityRepository.Update(userDhikrActivity);

            return Unit.Value;
        }
    }
}
