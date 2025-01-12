using AutoMapper;
using IbadahLover.Application.Exceptions;
using IbadahLover.Application.DTOs.UserSalahActivity.Validators;
using IbadahLover.Application.Features.UserSalahActivities.Requests.Commands;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserSalahActivities.Handlers.Commands
{
    public class UpdateUserSalahActivityCommandHandler : IRequestHandler<UpdateUserSalahActivityCommand, Unit>
    {
        private readonly IUserSalahActivityRepository _userSalahActivityRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly ISalahTypeRepository _salahTypeRepository;
        private readonly IMapper _mapper;

        public UpdateUserSalahActivityCommandHandler(IUserSalahActivityRepository userSalahActivityRepository, IUserAccountRepository userAccountRepository, ISalahTypeRepository salahTypeRepository, IMapper mapper)
        {
            _userSalahActivityRepository = userSalahActivityRepository;
            _userAccountRepository = userAccountRepository;
            _salahTypeRepository = salahTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserSalahActivityCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserSalahActivityDtoValidator(_userSalahActivityRepository, _userAccountRepository, _salahTypeRepository); //need to give the 3 repositories as parameter as in dto
            var validationResult = await validator.ValidateAsync(request.UserSalahActivityDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var userSalahActivity = await _userSalahActivityRepository.GetUserSalahActivityByTrackedOn(request.UserSalahActivityDto.UserAccountId.Value, request.UserSalahActivityDto.TrackedOn, request.UserSalahActivityDto.SalahTypeId);

            _mapper.Map(request.UserSalahActivityDto, userSalahActivity);

            await _userSalahActivityRepository.Update(userSalahActivity);

            return Unit.Value;
        }
    }
}
