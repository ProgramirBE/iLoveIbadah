using AutoMapper;
using IbadahLover.Application.DTOs.PermissionType;
using IbadahLover.Application.DTOs.RoleType;
using IbadahLover.Application.Features.PermissionTypes.Requests.Queries;
using IbadahLover.Application.Features.RoleTypes.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.RoleTypes.Handlers.Queries
{
    public class GetRoleTypeListRequestHandler : IRequestHandler<GetRoleTypeListRequest, List<RoleTypeListDto>>
    {
        private readonly IRoleTypeRepository _roleTypeRepository;
        private readonly IMapper _mapper;

        public GetRoleTypeListRequestHandler(IRoleTypeRepository roleTypeRepository, IMapper mapper)
        {
            _roleTypeRepository = roleTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<RoleTypeListDto>> Handle(GetRoleTypeListRequest request, CancellationToken cancellationToken)
        {
            var roleTypes = await _roleTypeRepository.GetAll();
            return _mapper.Map<List<RoleTypeListDto>>(roleTypes);
        }
    }
}
