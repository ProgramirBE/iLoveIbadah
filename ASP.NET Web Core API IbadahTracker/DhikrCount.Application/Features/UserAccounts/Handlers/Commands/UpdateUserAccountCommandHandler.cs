using AutoMapper;
using DhikrCount.Application.Features.UserAccounts.Requests.Commands;
using DhikrCount.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DhikrCount.Application.Features.UserAccounts.Handlers.Commands
{
    public class UpdateUserAccountCommandHandler : IRequestHandler<UpdateUserAccountCommand, Unit>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;

        public UpdateUserAccountCommandHandler(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetById(request.UserAccountDto.Id);

            _mapper.Map(request.UserAccountDto, userAccount);

            await _userAccountRepository.Update(userAccount);

            return Unit.Value;
        }
    }
}
