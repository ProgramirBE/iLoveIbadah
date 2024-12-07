using FluentValidation;
using IbadahLover.Application.DTOs.UserSalahActivity;
using IbadahLover.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserSalahActivity.Validators
{
    public class CreateUserSalahActivityDtoValidator : AbstractValidator<CreateUserSalahActivityDto>
    {
        private readonly IUserSalahActivityRepository _userSalahActivityRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly ISalahTypeRepository _salahTypeRepository;
        public CreateUserSalahActivityDtoValidator(IUserSalahActivityRepository userSalahActivityRepository, IUserAccountRepository userAccountRepository, ISalahTypeRepository salahTypeRepository)
        {
            _userSalahActivityRepository = userSalahActivityRepository;
            _userAccountRepository = userAccountRepository;
            _salahTypeRepository = salahTypeRepository;

            RuleFor(p => p.UserAccountId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var userAccountExists = await _userAccountRepository.Exists(id);
                    return !userAccountExists;
                });

            RuleFor(p => p.SalahTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var salahTypeExists = await _salahTypeRepository.Exists(id);
                    return !salahTypeExists;
                });

            RuleFor(p => p.TrackedOn)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (dto, trackedOn, token) =>
                {
                    var userSalahActivityTrackedOnExists = await _userSalahActivityRepository.TrackedOnExists(dto.UserAccountId, trackedOn);
                    return userSalahActivityTrackedOnExists; // il ne doit pas exister un activity pour cette journée pour cette utilisateur pour ce salahtype, sinon juste update allowed
                });
        }
    }
}