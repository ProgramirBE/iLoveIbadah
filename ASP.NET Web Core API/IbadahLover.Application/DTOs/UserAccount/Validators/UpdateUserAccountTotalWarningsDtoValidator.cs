using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount.Validators
{
    public class UpdateUserAccountTotalWarningsDtoValidator : AbstractValidator<UpdateUserAccountTotalWarningsDto>
    {
        public UpdateUserAccountTotalWarningsDtoValidator()
        {
            RuleFor(p => p.TotalWarnings)
                .NotNull().WithMessage("{PropertyName} must be provided.")
                .Equals(1);
        }
    }
}
