using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount.Validators
{
    public class UpdateUserAccountForOAuthUsersDtoValidator : AbstractValidator<UpdateUserAccountForFormUsersDto>
    {
        public UpdateUserAccountForOAuthUsersDtoValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed 25 characters.");
        }
    }
}
