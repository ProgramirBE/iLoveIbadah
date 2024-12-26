using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount.Validators
{
    public class CreateUserAccountDtoValidator : AbstractValidator<CreateUserAccountDto>
    {
        public CreateUserAccountDtoValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

            RuleFor(p => p.PasswordHash)
                .NotEmpty().WithMessage("{PropertyName} is required.");
                //.NotNull().When(p => p.OAuthId == null).WithMessage("Either {PropertyName} or OAuthId must be provided.");

            //RuleFor(p => p.OAuthId)
            //.NotNull().When(p => p.PasswordHash == null).WithMessage("Either {PropertyName} or PasswordHash must be provided.");
        }
    }
}
