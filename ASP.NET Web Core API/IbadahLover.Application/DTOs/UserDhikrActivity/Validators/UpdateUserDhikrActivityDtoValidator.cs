using FluentValidation;
using IbadahLover.Application.Persistence.Contracts;
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
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var userAccountExists = await _userAccountRepository.Exists(id);
                    return !userAccountExists;
                });

            RuleFor(p => p.DhikrTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var dhikrTypeExists = await _dhikrTypeRepository.Exists(id);
                    return !dhikrTypeExists;
                });

            RuleFor(p => p.PerformedOn)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (dto, performedOn, token) =>
                {
                    var userDhikrActivityPerformedOnExists = await _userDhikrActivityRepository.PerformedOnExists(dto.UserAccountId, performedOn);
                    return !userDhikrActivityPerformedOnExists; // il doit! exister un activity pour cette journée pour cette utilisateur pour ce dhikrtype, sinon juste create allowed
                });
        }
    }
}