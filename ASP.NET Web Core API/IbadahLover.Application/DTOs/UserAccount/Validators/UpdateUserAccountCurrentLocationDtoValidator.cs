using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount.Validators
{
    public class UpdateUserAccountCurrentLocationDtoValidator : AbstractValidator<UpdateUserAccountCurrentLocationDto>
    {
        public UpdateUserAccountCurrentLocationDtoValidator()
        {
            //RuleFor(p => p.CurrentLatitude)
            //    .NotNull().WithMessage("{PropertyName} must be provided.")
            //    .InclusiveBetween(-90, 90).WithMessage("{PropertyName} must be between -90 and 90 degrees.");

            //RuleFor(p => p.CurrentLongitude)
            //    .NotNull().WithMessage("{PropertyName} must be provided.")
            //    .InclusiveBetween(-180, 180).WithMessage("{PropertyName} must be between -180 and 180 degrees.");

            RuleFor(p => p.CurrentLocation)
                .NotNull().WithMessage("{PropertyName} must be provided.")
                .MaximumLength(75);
        }
    }
}
