using FluentValidation;
using IbadahLover.Application.DTOs.UserDhikrOverview;
using IbadahLover.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserDhikrOverview.Validators
{
    public class UpdateUserDhikrOverviewDtoValidator : AbstractValidator<UpdateUserDhikrOverviewDto>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IDhikrTypeRepository _dhikrTypeRepository;
        public UpdateUserDhikrOverviewDtoValidator(IUserAccountRepository userAccountRepository, IDhikrTypeRepository dhikrTypeRepository)
        {
            _userAccountRepository = userAccountRepository;
            _dhikrTypeRepository = dhikrTypeRepository;

            RuleFor(p => p.UserAccountId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var dhikrTypeExists = await _dhikrTypeRepository.Exists(id);
                    return !dhikrTypeExists;
                });

            RuleFor(p => p.TotalPerformed)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0.");

            RuleFor(p => p.LastPerformedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
