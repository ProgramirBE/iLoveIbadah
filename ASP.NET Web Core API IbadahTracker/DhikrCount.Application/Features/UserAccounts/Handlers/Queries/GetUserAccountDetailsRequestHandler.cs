using AutoMapper;
using DhikrCount.Application.DTOs.UserAccount;
using DhikrCount.Application.Features.DhikrTypes.Requests.Queries;
using DhikrCount.Application.Features.UserAccounts.Requests.Queries;
using DhikrCount.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.Features.UserAccounts.Handlers.Queries
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
