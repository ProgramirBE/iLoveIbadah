using FluentValidation;
using IbadahLover.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.DhikrType.Validators
{
    public class CreateDhikrTypeDtoValidator : AbstractValidator<CreateDhikrTypeDto>
    {
        private readonly IDhikrTypeRepository _dhikrTypeRepository;
        private readonly IUserAccountRepository _userAccountRepository;

        public CreateDhikrTypeDtoValidator(IDhikrTypeRepository dhikrTypeRepository, IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
            _dhikrTypeRepository = dhikrTypeRepository;

            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

            RuleFor(p => p.CreatedBy)
                .Must(id => true) // Always valid since it's set by the server
                .WithMessage("UserAccountId is not validated directly.")
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var userAccountExists = await _userAccountRepository.Exists(id.Value);
                    return userAccountExists;
                })
                .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.ArabicFullName)
                .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.")
                .When(p => p.ArabicFullName != null);
        }
    }
}
