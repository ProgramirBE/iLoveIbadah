using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount.Validators
{
    public class UpdateUserAccountPasswordHashDtoValidator : AbstractValidator<UpdateUserAccountPasswordHashDto>
    {
        public UpdateUserAccountPasswordHashDtoValidator()
        {
            RuleFor(p => p.PasswordHash)
                .NotNull().WithMessage("{PropertyName} must be provided.");
        }
    }
}
