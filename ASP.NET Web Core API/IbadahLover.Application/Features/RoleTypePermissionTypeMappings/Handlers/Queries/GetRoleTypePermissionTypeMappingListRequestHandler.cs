using AutoMapper;
using IbadahLover.Application.DTOs.RoleTypePermissionTypeMapping;
using IbadahLover.Application.Features.RoleTypePermissionTypeMappings.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.RoleTypePermissionTypeMappings.Handlers.Queries
{
    public class GetRoleTypePermissionTypeMappingListRequestHandler : IRequestHandler<GetRoleTypePermissionTypeMappingListRequest, List<RoleTypePermissionTypeMappingListDto>>
    {
        private readonly IRoleTypePermissionTypeMappingRepository _roleTypePermissionTypeMappingRepository;
        private readonly IMapper _mapper;

        public GetRoleTypePermissionTypeMappingListRequestHandler(IRoleTypePermissionTypeMappingRepository roleTypePermissionTypeMappingRepository, IMapper mapper)
        {
            _roleTypePermissionTypeMappingRepository = roleTypePermissionTypeMappingRepository;
            _mapper = mapper;
        }
        public async Task<List<RoleTypePermissionTypeMappingListDto>> Handle(GetRoleTypePermissionTypeMappingListRequest request, CancellationToken cancellationToken)
        {
            var roleTypesPermissionTypeMappings = await _roleTypePermissionTypeMappingRepository.GetAll();
            return _mapper.Map<List<RoleTypePermissionTypeMappingListDto>>(roleTypesPermissionTypeMappings);
        }
    }
}
