using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserActivity.Validators
{
    public class UpdateUserActivityDtoValidator : AbstractValidator<UpdateUserActivityDto>
    {
        public UpdateUserActivityDtoValidator()
        {
            RuleFor(p => p.UserAccountId)
                .NotEmpty();

            RuleFor(p => p.DhikrTypeId)
                .NotEmpty();

            RuleFor(p => p.PerformedAt)
                .NotEmpty();
        }
    }
}
