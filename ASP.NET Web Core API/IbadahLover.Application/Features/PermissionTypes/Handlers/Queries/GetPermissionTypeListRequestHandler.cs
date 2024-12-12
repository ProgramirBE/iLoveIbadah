using AutoMapper;
using IbadahLover.Application.DTOs.PermissionType;
using IbadahLover.Application.Features.PermissionTypes.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.PermissionTypes.Handlers.Queries
{
    public class GetPermissionTypeListRequestHandler : IRequestHandler<GetPermissionTypeListRequest, List<PermissionTypeListDto>>
    {
        private readonly IPermissionTypeRepository _permissionTypeRepository;
        private readonly IMapper _mapper;

        public GetPermissionTypeListRequestHandler(IPermissionTypeRepository permissionTypeRepository, IMapper mapper)
        {
            _permissionTypeRepository = permissionTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<PermissionTypeListDto>> Handle(GetPermissionTypeListRequest request, CancellationToken cancellationToken)
        {
            var permissionTypes = await _permissionTypeRepository.GetAll();
            return _mapper.Map<List<PermissionTypeListDto>>(permissionTypes);
        }

    }
}
