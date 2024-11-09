using AutoMapper;
using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.DTOs.UserAccount.Validators;
using IbadahLover.Application.Features.UserAccounts.Requests.Commands;
using IbadahLover.Application.Persistence.Contracts;
using IbadahLover.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserAccounts.Handlers.Commands
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, int>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;

        public CreateUserAccountCommandHandler(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserAccountDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UserAccountDto);

            //var validationResult = await validator.ValidateAsync(new CreateUserAccountDto
            //{
            //    // Copy properties from UserAccountDto to CreateUserAccountDto
            //    Property1 = request.UserAccountDto.Property1,
            //    Property2 = request.UserAccountDto.Property2,
            //    // Add more properties as needed
            //});

            if (!validationResult.IsValid)
            {
                throw new Exception();
            }

            var userAccount = _mapper.Map<UserAccount>(request.UserAccountDto);
            userAccount = await _userAccountRepository.Create(userAccount);

            return userAccount.Id;
        }
    }
}
