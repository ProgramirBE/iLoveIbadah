using FluentValidation;
using IbadahLover.Application.DTOs.UserDhikrOverview;
using IbadahLover.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserDhikrOverview.Validators
{
    //public class UpdateUserDhikrOverviewDtoValidator : AbstractValidator<UpdateUserDhikrOverviewDto>
    //{
    //    private readonly IUserAccountRepository _userAccountRepository;
    //    public UpdateUserDhikrOverviewDtoValidator(IUserAccountRepository userAccountRepository)
    //    {
    //        _userAccountRepository = userAccountRepository;

    //        RuleFor(p => p.UserAccountId)
    //            .NotEmpty().WithMessage("{PropertyName} is required.")
    //            .NotNull()
    //            .MustAsync(async (id, token) =>
    //            {
    //                var userAccountExists = await _userAccountRepository.Exists(id);
    //                return !userAccountExists;
    //            });

    //        RuleFor(p => p.TotalPerformed)
    //            .NotEmpty().WithMessage("{PropertyName} is required.")
    //            .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0.");

    //        RuleFor(p => p.LastPerformedAt)
    //            .NotEmpty().WithMessage("{PropertyName} is required.");
    //    }
    //}
}
