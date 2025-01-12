using AutoMapper;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.DTOs.DhikrType;
using IbadahLover.Application.Features.DhikrTypes.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.DhikrTypes.Handlers.Queries
{
    public class GetDhikrTypeByUserAccountListRequestHandler : IRequestHandler<GetDhikrTypeByUserAccountListRequest, List<DhikrTypeByUserAccountListDto>>
    {
        private readonly IDhikrTypeRepository _dhikrTypeRepository;
        private IMapper _mapper;

        public GetDhikrTypeByUserAccountListRequestHandler(IDhikrTypeRepository dhikrTypeRepository, IMapper mapper)
        {
            _dhikrTypeRepository = dhikrTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<DhikrTypeByUserAccountListDto>> Handle(GetDhikrTypeByUserAccountListRequest request, CancellationToken cancellationToken)
        {
            var dhikrTypes = await _dhikrTypeRepository.GetDhikrTypesByUserAccountId(request.CreatedBy);
            return _mapper.Map<List<DhikrTypeByUserAccountListDto>>(dhikrTypes);
        }
    }
}
