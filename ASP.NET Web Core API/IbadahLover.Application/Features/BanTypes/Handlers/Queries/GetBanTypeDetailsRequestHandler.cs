using AutoMapper;
using IbadahLover.Application.DTOs.BanType;
using IbadahLover.Application.Features.BanTypes.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.BanTypes.Handlers.Queries
{
    //public class GetBanTypeDetailsRequestHandler
    //{
    //    private readonly IBanTypeRepository _banTypeRepository;
    //    private readonly IMapper _mapper;

    //    public GetBanTypeDetailsRequestHandler(IBanTypeRepository banTypeRepository, IMapper mapper)
    //    {
    //        _banTypeRepository = banTypeRepository;
    //        _mapper = mapper;
    //    }
    //    public async Task<BanTypeDto> Handle(GetBanTypeDetailsRequest request, CancellationToken cancellationToken)
    //    {
    //        var banType = await _banTypeRepository.GetById(request.Id);
    //        return _mapper.Map<BanTypeDto>(banType);
    //    }
    //}
}
