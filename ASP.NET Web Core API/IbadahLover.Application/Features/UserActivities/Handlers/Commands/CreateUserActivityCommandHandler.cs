using AutoMapper;
using IbadahLover.Application.DTOs.UserAccount.Validators;
using IbadahLover.Application.Features.UserAccounts.Requests.Commands;
using IbadahLover.Application.Features.UserActivities.Requests.Commands;
using IbadahLover.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserActivities.Handlers.Commands
{
    public class CreateUserActivityCommandHandler : IRequestHandler<CreateUserActivityCommand, int>
    {
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly IMapper _mapper;

        public CreateUserActivityCommandHandler(IUserActivityRepository userActivityRepository, IMapper mapper)
        {
            _userActivityRepository = userActivityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserActivityCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserActivityDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UserActivityDto);

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

            var userActivity = _mapper.Map<UserActivity>(request.UserActivityDto);
            userActivity = await _userActivityRepository.Create(userActivity);

            return userActivity.Id;
        }
    }
}
