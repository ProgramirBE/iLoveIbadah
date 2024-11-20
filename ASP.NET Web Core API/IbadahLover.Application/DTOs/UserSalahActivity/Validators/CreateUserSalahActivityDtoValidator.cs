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

            RuleFor(p => p.PerformedOn)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (dto, performedOn, token) =>
                {
                    var userSalahActivityPerformedAtExists = await _userSalahActivityRepository.PerformedOnExists(dto.UserAccountId, performedOn);
                    return userSalahActivityPerformedAtExists; // il ne doit pas exister de activity pour cette journée pour cette utilisateur pour ce salahtype, sinon juste update allowed
                });
        }
    }
}