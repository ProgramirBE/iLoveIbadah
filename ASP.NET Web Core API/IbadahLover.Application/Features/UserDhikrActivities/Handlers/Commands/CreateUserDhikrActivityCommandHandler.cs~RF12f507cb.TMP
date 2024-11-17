using AutoMapper;
using IbadahLover.Application.DTOs.UserAccount.Validators;
using IbadahLover.Application.Features.UserAccounts.Requests.Commands;
using IbadahLover.Application.Features.UserDhikrActivities.Requests.Commands;
using IbadahLover.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrActivities.Handlers.Commands
{
    public class CreateUserDhikrActivityCommandHandler : IRequestHandler<CreateUserDhikrActivityCommand, int>
    {
        private readonly IUserDhikrActivityRepository _userDhikrActivityRepository;
        private readonly IMapper _mapper;

        public CreateUserDhikrActivityCommandHandler(IUserDhikrActivityRepository userDhikrActivityRepository, IMapper mapper)
        {
            _userDhikrActivityRepository = userDhikrActivityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserDhikrActivityCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserDhikrActivityDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UserDhikrActivityDto);

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

            var userDhikrActivity = _mapper.Map<UserDhikrActivity>(request.UserDhikrActivityDto);
            userDhikrActivity = await _userDhikrActivityRepository.Create(userDhikrActivity);

            return userDhikrActivity.Id;
        }
    }
}
