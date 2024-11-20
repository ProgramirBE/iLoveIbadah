using FluentValidation;
using IbadahLover.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserDhikrActivity.Validators
{
    public class CreateUserDhikrActivityDtoValidator : AbstractValidator<CreateUserDhikrActivityDto>
    {
        private readonly IUserDhikrActivityRepository _userDhikrActivityRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IDhikrTypeRepository _dhikrTypeRepository;
        public CreateUserDhikrActivityDtoValidator(IUserDhikrActivityRepository userDhikrActivityRepository, IUserAccountRepository userAccountRepository, IDhikrTypeRepository dhikrTypeRepository)
        {
            _userDhikrActivityRepository = userDhikrActivityRepository;
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
                    var userDhikrActivityPerformedAtExists = await _userDhikrActivityRepository.PerformedAtExists(id);
                    return !userDhikrActivityPerformedAtExists;
                });
        }
    }
}
