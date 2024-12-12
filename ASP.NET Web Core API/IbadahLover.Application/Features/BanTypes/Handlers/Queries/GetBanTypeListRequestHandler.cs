using AutoMapper;
using IbadahLover.Application.DTOs.BanType;
using IbadahLover.Application.Features.BanTypes.Requests.Queries;
using IbadahLover.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.BanTypes.Handlers.Queries
{
    //public class GetBanTypeListRequestHandler : IRequestHandler<GetBanTypeListRequest, List<BanTypeListDto>>
    //{
    //    private readonly IBanTypeRepository _banTypeRepository;
    //    private readonly IMapper _mapper;

    //    public GetBanTypeListRequestHandler(IBanTypeRepository banTypeRepository, IMapper mapper)
    //    {
    //        _banTypeRepository = banTypeRepository;
    //        _mapper = mapper;
    //    }
    //    public async Task<List<BanTypeListDto>> Handle(GetBanTypeListRequest request, CancellationToken cancellationToken)
    //    {
    //        var banTypes = await _banTypeRepository.GetAll();
    //        return _mapper.Map<List<BanTypeListDto>>(banTypes);
    //    }
    //}
}
