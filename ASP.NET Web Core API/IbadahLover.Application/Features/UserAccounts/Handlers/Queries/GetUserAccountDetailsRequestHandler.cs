using AutoMapper;
using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.Features.DhikrTypes.Requests.Queries;
using IbadahLover.Application.Features.UserAccounts.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserAccounts.Handlers.Queries
{
    // Backend Handler of Request to get Details of User Account
    public class GetUserAccountDetailsRequestHandler : IRequestHandler<GetUserAccountDetailsRequest, UserAccountDto>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;

        public GetUserAccountDetailsRequestHandler(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }
        public async Task<UserAccountDto> Handle(GetUserAccountDetailsRequest request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetById(request.Id);
            return _mapper.Map<UserAccountDto>(userAccount);
        }
    }
}
