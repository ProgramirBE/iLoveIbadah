using FluentValidation;
using IbadahLover.Application.DTOs.UserSalahOverview;
using IbadahLover.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserSalahOverview.Validators
{
    //public class UpdateUserSalahOverviewDtoValidator : AbstractValidator<UpdateUserSalahOverviewDto>
    //{
    //    private readonly IUserAccountRepository _userAccountRepository;
    //    public UpdateUserSalahOverviewDtoValidator(IUserAccountRepository userAccountRepository)
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

    //        RuleFor(p => p.TotalTracked)
    //            .NotEmpty().WithMessage("{PropertyName} is required.")
    //            .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0.");

    //        RuleFor(p => p.LastTrackedAt)
    //            .NotEmpty().WithMessage("{PropertyName} is required.");
    //    }
    //}
}
