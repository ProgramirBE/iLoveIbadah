using AutoMapper;
using IbadahLover.Application.DTOs.UserDhikrActivity.Validators;
using IbadahLover.Application.Exceptions;
using IbadahLover.Application.Features.UserDhikrActivities.Requests.Commands;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.Responses;
using IbadahLover.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrActivities.Handlers.Commands
{
    public class CreateUserDhikrActivityCommandHandler : IRequestHandler<CreateUserDhikrActivityCommand, BaseCommandResponse>
    {
        private readonly IUserDhikrActivityRepository _userDhikrActivityRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IDhikrTypeRepository _dhikrTypeRepository;
        private readonly IMapper _mapper;

        public CreateUserDhikrActivityCommandHandler(IUserDhikrActivityRepository userDhikrActivityRepository, IUserAccountRepository userAccountRepository, IDhikrTypeRepository dhikrTypeRepository, IMapper mapper)
        {
            _userDhikrActivityRepository = userDhikrActivityRepository;
            _userAccountRepository = userAccountRepository;
            _dhikrTypeRepository = dhikrTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserDhikrActivityCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUserDhikrActivityDtoValidator(_userDhikrActivityRepository, _userAccountRepository, _dhikrTypeRepository); //need to give the 3 repositories as parameter as in dto
            var validationResult = await validator.ValidateAsync(request.UserDhikrActivityDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                //throw new ValidationException(validationResult);
            }

            var userDhikrActivity = _mapper.Map<UserDhikrActivity>(request.UserDhikrActivityDto);
            userDhikrActivity = await _userDhikrActivityRepository.Create(userDhikrActivity);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = userDhikrActivity.Id;

            return response;
        }
    }
}
