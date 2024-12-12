using AutoMapper;
using IbadahLover.Application.DTOs.SalahType;
using IbadahLover.Application.Features.SalahTypes.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.SalahTypes.Handlers.Queries
{
    public class GetSalahTypeListRequestHandler : IRequestHandler<GetSalahTypeListRequest, List<SalahTypeListDto>>
    {
        private readonly ISalahTypeRepository _salahTypeRepository;
        private readonly IMapper _mapper;

        public GetSalahTypeListRequestHandler(ISalahTypeRepository salahTypeRepository, IMapper mapper)
        {
            _salahTypeRepository = salahTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<SalahTypeListDto>> Handle(GetSalahTypeListRequest request, CancellationToken cancellationToken)
        {
            var salahTypes = await _salahTypeRepository.GetAll();
            return _mapper.Map<List<SalahTypeListDto>>(salahTypes);
        }

    }
}
