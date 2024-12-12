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
    public class GetPermissionTypeDetailsRequestHandler : IRequestHandler<GetPermissionTypeDetailsRequest, PermissionTypeDto>
    {
        private readonly IPermissionTypeRepository _permissionTypeRepository;
        private readonly IMapper _mapper;

        public GetPermissionTypeDetailsRequestHandler(IPermissionTypeRepository permissionTypeRepository, IMapper mapper)
        {
            _permissionTypeRepository = permissionTypeRepository;
            _mapper = mapper;
        }
        public async Task<PermissionTypeDto> Handle(GetPermissionTypeDetailsRequest request, CancellationToken cancellationToken)
        {
            var permissionType = await _permissionTypeRepository.GetById(request.Id);
            return _mapper.Map<PermissionTypeDto>(permissionType);
        }
    }
}
