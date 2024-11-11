using FluentValidation;
using IbadahLover.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserActivity.Validators
{
    public class CreateUserActivityDtoValidator : AbstractValidator<CreateUserActivityDto>
    {
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IDhikrTypeRepository _dhikrTypeRepository;
        public CreateUserActivityDtoValidator(IUserActivityRepository userActivityRepository, IUserAccountRepository userAccountRepository, IDhikrTypeRepository dhikrTypeRepository)
        {
            _userActivityRepository = userActivityRepository;
            _userAccountRepository = userAccountRepository;
            _dhikrTypeRepository = dhikrTypeRepository;

            RuleFor(p => p.UserAccountId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var userAccountExists = await _userAccountRepository.Exists(id);
                    return !userAccountExists;
                });

            RuleFor(p => p.DhikrTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var dhikrTypeExists = await _dhikrTypeRepository.Exists(id);
                    return !dhikrTypeExists;
                });

            RuleFor(p => p.PerformedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var userActivityPerformedAtExists = await _userActivityRepository.PerformedAtExists(id);
                    return !userActivityPerformedAtExists;
                });
        }
    }
}
