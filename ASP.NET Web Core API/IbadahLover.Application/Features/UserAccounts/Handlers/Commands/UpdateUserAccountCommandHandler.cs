using AutoMapper;
using IbadahLover.Application.DTOs.UserAccount.Validators;
using IbadahLover.Application.Exceptions;
using IbadahLover.Application.Features.UserAccounts.Requests.Commands;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IbadahLover.Application.Contracts.Identity;
using IbadahLover.Domain;

namespace IbadahLover.Application.Features.UserAccounts.Handlers.Commands
{
    public class UpdateUserAccountCommandHandler : IRequestHandler<UpdateUserAccountCommand, Unit>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IProfilePictureTypeRepository _profilePictureTypeRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateUserAccountCommandHandler(IUserAccountRepository userAccountRepository, IMapper mapper, IUserService userService)
        {
            _userAccountRepository = userAccountRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserAccountCommand request, CancellationToken cancellationToken)
        {

            //var response = new BaseCommandResponse();

            //var validator = new UpdateUserAccountDtoValidator(); //need to give the 3 repositories as parameter as in dto
            //var validationResult = await validator.ValidateAsync(request.UserAccountDto);

            //if (!validationResult.IsValid)
            //{
            //    //response.Success = false;
            //    //response.Message = "Update Failed";
            //    //response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            //    throw new ValidationException(validationResult);
            //}

            if (request.UserAccountDto != null)
            {
                var userAccount = await _userAccountRepository.GetById(request.Id);
                if (userAccount == null)
                {
                    throw new NotFoundException(nameof(UserAccount), request.Id);
                }

                // Update application-specific fields
                userAccount.FullName = request.UserAccountDto.FullName;
                userAccount.ProfilePictureTypeId = request.UserAccountDto.ProfilePictureTypeId;
                await _userAccountRepository.Update(userAccount);
            }

            if (request.UserAccountPasswordHashDto != null)
            {
                // Update password via UserService
                await _userService.UpdateUserAccountPasswordHash(
                    request.Id,
                    request.UserAccountPasswordHashDto.CurrentPasswordHash,
                    request.UserAccountPasswordHashDto.NewPasswordHash
                );
            }
            //--------------------------------------------------------------------------------
            //var userAccount = await _userAccountRepository.GetById(request.UserAccountDto.Id);

            //_mapper.Map(request.UserAccountDto, userAccount);

            //await _userAccountRepository.Update(userAccount);

            //response.Success = true;
            //response.Message = "Update Successful";
            //response.Id = userAccount.Id;
            return Unit.Value;
        }
    }
}
