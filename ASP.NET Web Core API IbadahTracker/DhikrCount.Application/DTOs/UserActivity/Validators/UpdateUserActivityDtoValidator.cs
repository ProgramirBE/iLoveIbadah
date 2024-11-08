using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.DTOs.UserActivity.Validators
{
    public class UpdateUserActivityDtoValidator : AbstractValidator<UpdateUserActivityDto>
    {
        public UpdateUserActivityDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty();

            RuleFor(p => p.TotalDhikrPerformed)
                .NotEmpty()
                .GreaterThan(0)
                .LessThan(2);
        }
    }
}
