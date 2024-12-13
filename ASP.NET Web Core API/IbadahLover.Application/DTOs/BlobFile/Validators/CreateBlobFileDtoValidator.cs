using FluentValidation;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.DTOs.BlobFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.BlobFile.Validators
{
    public class CreateBlobFileDtoValidator : AbstractValidator<CreateBlobFileDto>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        public CreateBlobFileDtoValidator(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;

            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters.");

            RuleFor(p => p.Uri)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(300).WithMessage("{PropertyName} must not exceed 300 characters.");

            RuleFor(p => p.Extension)
                .NotNull();

            RuleFor(p => p.CreatedBy)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var userAccountExists = await _userAccountRepository.Exists(id);
                    return userAccountExists;
                })
                .WithMessage("{PropertyName} does not exist.");

            //RuleFor(p => p.Size)
        }
    }
}
