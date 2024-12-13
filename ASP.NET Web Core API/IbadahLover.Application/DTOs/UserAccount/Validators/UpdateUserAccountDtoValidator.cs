using FluentValidation;
using IbadahLover.Application.DTOs.ProfilePictureType;
using IbadahLover.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount.Validators
{
    public class UpdateUserAccountDtoValidator : AbstractValidator<UpdateUserAccountDto>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IProfilePictureTypeRepository _profilePictureTypeRepository;
        public UpdateUserAccountDtoValidator(IProfilePictureTypeRepository profilePictureTypeRepository, IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
            _profilePictureTypeRepository = profilePictureTypeRepository;

            RuleFor(p => p)
                .Must(p => !string.IsNullOrWhiteSpace(p.FullName) || p.ProfilePictureTypeId.HasValue)
                .WithMessage("At least one of FullName or ProfilePictureTypeId must be provided.");

            RuleFor(p => p.FullName)
                .NotEmpty().NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters.")
                .When(p => !string.IsNullOrWhiteSpace(p.FullName));

            //RuleFor(p => p.Id)
            //    .GreaterThan(0)
            //    .MustAsync(async (id, token) =>
            //    {
            //        var userAccountExists = await _userAccountRepository.Exists(id);
            //        return !userAccountExists;
            //    })
            //    .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.ProfilePictureTypeId)
                .GreaterThan(0)
                .MustAsync(async (profilePictureTypeId, token) =>
                {
                    // If ProfilePictureTypeId is null, the rule won't run due to .When()
                    return profilePictureTypeId.HasValue && await _profilePictureTypeRepository.Exists(profilePictureTypeId.Value);
                })
                .WithMessage("{PropertyName} does not exist.")
                .When(p => p.ProfilePictureTypeId.HasValue);

            //RuleFor(p => p.ProfilePictureTypeId)
            //    .GreaterThan(0)
            //    .When(p => p.ProfilePictureTypeId.HasValue)
            //    .MustAsync(async (id, token) =>
            //    {
            //        var profilePictureTypeExists = await _profilePictureTypeRepository.Exists(id);
            //        return profilePictureTypeExists;
            //    })
            //    .WithMessage("{PropertyName} does not exist.");
        }
    }
}
