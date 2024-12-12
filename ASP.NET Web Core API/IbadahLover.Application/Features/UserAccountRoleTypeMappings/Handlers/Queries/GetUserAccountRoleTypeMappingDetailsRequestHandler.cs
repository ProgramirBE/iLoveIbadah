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
    public class GetUserAccountRoleTypeMappingDetailsRequestHandler : IRequestHandler<GetUserAccountRoleTypeMappingDetailsRequest, UserAccountRoleTypeMappingDto>
    {
        private readonly IUserAccountRoleTypeMappingRepository _userAccountRoleTypeMappingRepository;
        private readonly IMapper _mapper;

        public GetUserAccountRoleTypeMappingDetailsRequestHandler(IUserAccountRoleTypeMappingRepository userAccountRoleTypeMappingRepository, IMapper mapper)
        {
            _userAccountRoleTypeMappingRepository = userAccountRoleTypeMappingRepository;
            _mapper = mapper;
        }
        public async Task<UserAccountRoleTypeMappingDto> Handle(GetUserAccountRoleTypeMappingDetailsRequest request, CancellationToken cancellationToken)
        {
            var userAccountRoleTypeMapping = await _userAccountRoleTypeMappingRepository.GetById(request.Id);
            return _mapper.Map<UserAccountRoleTypeMappingDto>(userAccountRoleTypeMapping);
        }
    }
}
