using FluentValidation;
using IbadahLover.Application.DTOs.UserSalahActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserSalahActivity.Validators
{
    public class UpdateUserSalahActivityDtoValidator : AbstractValidator<UpdateUserSalahActivityDto>
    {
        public UpdateUserSalahActivityDtoValidator()
        {
            RuleFor(p => p.UserAccountId)
                .NotEmpty();

            RuleFor(p => p.SalahTypeId)
                .NotEmpty();

            RuleFor(p => p.PerformedOn)
                .NotEmpty();
        }
    }
}