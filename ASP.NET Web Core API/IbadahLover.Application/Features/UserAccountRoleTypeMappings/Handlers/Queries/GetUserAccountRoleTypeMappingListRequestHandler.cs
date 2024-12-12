using AutoMapper;
using IbadahLover.Application.DTOs.UserAccountRoleTypeMapping;
using IbadahLover.Application.Features.UserAccountRoleTypeMappings.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserAccountRoleTypeMappings.Handlers.Queries
{
    public class GetUserAccountRoleTypeMappingListRequestHandler : IRequestHandler<GetUserAccountRoleTypeMappingListRequest, List<UserAccountRoleTypeMappingListDto>>
    {
        private readonly IUserAccountRoleTypeMappingRepository _userAccountRoleTypeMappingRepository;
        private readonly IMapper _mapper;

        public GetUserAccountRoleTypeMappingListRequestHandler(IUserAccountRoleTypeMappingRepository userAccountRoleTypeMappingRepository, IMapper mapper)
        {
            _userAccountRoleTypeMappingRepository = userAccountRoleTypeMappingRepository;
            _mapper = mapper;
        }
        public async Task<List<UserAccountRoleTypeMappingListDto>> Handle(GetUserAccountRoleTypeMappingListRequest request, CancellationToken cancellationToken)
        {
            var userAccountRoleTypeMappings = await _userAccountRoleTypeMappingRepository.GetAll();
            return _mapper.Map<List<UserAccountRoleTypeMappingListDto>>(userAccountRoleTypeMappings);
        }
    }
}
