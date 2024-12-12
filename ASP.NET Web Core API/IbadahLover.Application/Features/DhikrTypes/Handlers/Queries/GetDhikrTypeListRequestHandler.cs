using AutoMapper;
using IbadahLover.Application.DTOs.DhikrType;
using IbadahLover.Application.Features.DhikrTypes.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.DhikrTypes.Handlers.Queries
{
    // Backend Handler of Request to get a List of Dhikr Types
    public class GetDhikrTypeListRequestHandler : IRequestHandler<GetDhikrTypeListRequest, List<DhikrTypeListDto>>
    {
        private readonly IDhikrTypeRepository _dhikrTypeRepository;
        private readonly IMapper _mapper;

        public GetDhikrTypeListRequestHandler(IDhikrTypeRepository dhikrTypeRepository, IMapper mapper)
        {
            _dhikrTypeRepository = dhikrTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<DhikrTypeListDto>> Handle(GetDhikrTypeListRequest request, CancellationToken cancellationToken)
        {
            var dhikrTypes = await _dhikrTypeRepository.GetAll();
            return _mapper.Map<List<DhikrTypeListDto>>(dhikrTypes);
        }

    }
}
