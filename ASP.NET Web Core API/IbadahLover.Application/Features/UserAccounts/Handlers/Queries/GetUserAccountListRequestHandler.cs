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
