using AutoMapper;
using IbadahLover.Application.DTOs.UserDhikrActivity.Validators;
using IbadahLover.Application.DTOs.UserSalahActivity.Validators;
using IbadahLover.Application.Features.UserDhikrActivities.Requests.Commands;
using IbadahLover.Application.Features.UserSalahActivities.Requests.Commands;
using IbadahLover.Application.Persistence.Contracts;
using IbadahLover.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserSalahActivities.Handlers.Commands
{
    public class CreateUserSalahActivityCommandHandler : IRequestHandler<CreateUserSalahActivityCommand, int>
    {
        private readonly IUserSalahActivityRepository _userSalahActivityRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly ISalahTypeRepository _salahTypeRepository;
        private readonly IMapper _mapper;

        public CreateUserSalahActivityCommandHandler(IUserSalahActivityRepository userSalahActivityRepository, IUserAccountRepository userAccountRepository, ISalahTypeRepository salahTypeRepository, IMapper mapper)
        {
            _userSalahActivityRepository = userSalahActivityRepository;
            _userAccountRepository = userAccountRepository;
            _salahTypeRepository = salahTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserSalahActivityCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserSalahActivityDtoValidator(_userSalahActivityRepository, _userAccountRepository, _salahTypeRepository); //need to give the 3 repositories as parameter as in dto
            var validationResult = await validator.ValidateAsync(request.UserSalahActivityDto);

            //var validationResult = await validator.ValidateAsync(new CreateUserAccountDto
            //{
            //    // Copy properties from UserAccountDto to CreateUserAccountDto
            //    Property1 = request.UserAccountDto.Property1,
            //    Property2 = request.UserAccountDto.Property2,
            //    // Add more properties as needed
            //});   

            if (!validationResult.IsValid)
            {
                throw new Exception();
            }

            var userSalahActivity = _mapper.Map<UserSalahActivity>(request.UserSalahActivityDto);
            userSalahActivity = await _userSalahActivityRepository.Create(userSalahActivity);

            return userSalahActivity.Id;
        }
    }
}
