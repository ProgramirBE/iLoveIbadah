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
    // Backend Handler of Request to get a List of User Accounts
    public class GetUserAccountListRequestHandler : IRequestHandler<GetUserAccountListRequest, List<UserAccountListDto>>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;

        public GetUserAccountListRequestHandler(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }
        public async Task<List<UserAccountListDto>> Handle(GetUserAccountListRequest request, CancellationToken cancellationToken)
        {
            var userAccounts = await _userAccountRepository.GetAll();
            return _mapper.Map<List<UserAccountListDto>>(userAccounts);
        }
    }
}
