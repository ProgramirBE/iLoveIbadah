using FluentValidation;
using IbadahLover.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserDhikrActivity.Validators
{
    public class UpdateUserDhikrActivityDtoValidator : AbstractValidator<UpdateUserDhikrActivityDto>
    {
        private readonly IUserDhikrActivityRepository _userDhikrActivityRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IDhikrTypeRepository _dhikrTypeRepository;
        public UpdateUserDhikrActivityDtoValidator(IUserDhikrActivityRepository userDhikrActivityRepository, IUserAccountRepository userAccountRepository, IDhikrTypeRepository dhikrTypeRepository)
        {
            _userDhikrActivityRepository = userDhikrActivityRepository;
            _userAccountRepository = userAccountRepository;
            _dhikrTypeRepository = dhikrTypeRepository;

            RuleFor(p => p.UserAccountId)
                .Must(id => true) // Always valid since it's set by the server
                .WithMessage("UserAccountId is not validated directly.")
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var userAccountExists = await _userAccountRepository.Exists(id.Value);
                    return userAccountExists;
                })
                .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.DhikrTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var dhikrTypeExists = await _dhikrTypeRepository.Exists(id);
                    return dhikrTypeExists;
                })
                .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.PerformedOn)
                .LessThanOrEqualTo(DateTime.Now)
                .MustAsync(async (dto, performedOn, token) =>
                {
                    var userDhikrActivityPerformedOnExists = await _userDhikrActivityRepository.PerformedOnExists(dto.UserAccountId.Value, performedOn, dto.DhikrTypeId);
                    return userDhikrActivityPerformedOnExists; // il doit! exister un activity pour cette journée pour cette utilisateur pour ce dhikrtype, sinon juste create allowed
                })
                .WithMessage("{PropertyName} is required in order to update, else create for this date.");
        }
    }
}