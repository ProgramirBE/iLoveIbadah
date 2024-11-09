using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserActivity.Validators
{
    public class CreateUserActivityDtoValidator : AbstractValidator<CreateUserActivityDto>
    {
        public CreateUserActivityDtoValidator()
        {
            RuleFor(p => p.UserAccountId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.DhikrTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.TotalDhikrPerformed)
                .NotNull()
                .GreaterThan(0);

            //RuleFor(p => p)
            //.Custom((dto, context) =>
            //{
            //    var existingActivity = _activityRepository.GetActivityForToday(dto.UserAccountId, dto.DhikrTypeId);
            //    if (existingActivity != null)
            //    {
            //        context.AddFailure("A record for today already exists.");
            //    }
            //});
        }
    }
}
