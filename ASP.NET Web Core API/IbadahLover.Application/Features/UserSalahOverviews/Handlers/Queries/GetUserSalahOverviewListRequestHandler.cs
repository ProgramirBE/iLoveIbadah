﻿using AutoMapper;
using IbadahLover.Application.DTOs.UserSalahOverview;
using IbadahLover.Application.Features.UserSalahOverviews.Requests.Queries;
using IbadahLover.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserSalahOverviews.Handlers.Queries
{
    public class GetUserSalahOverviewListRequestHandler : IRequestHandler<GetUserSalahOverviewListRequest, List<UserSalahOverviewListDto>>
    {
        private readonly IUserSalahOverviewRepository _userSalahOverviewRepository;
        private readonly IMapper _mapper;
        public GetUserSalahOverviewListRequestHandler(IUserSalahOverviewRepository userSalahOverviewRepository, IMapper mapper)
        {
            _userSalahOverviewRepository = userSalahOverviewRepository;
            _mapper = mapper;
        }
        public async Task<List<UserSalahOverviewListDto>> Handle(GetUserSalahOverviewListRequest request, CancellationToken cancellationToken)
        {
            var userSalahOverviews = await _userSalahOverviewRepository.GetAll();
            return _mapper.Map<List<UserSalahOverviewListDto>>(userSalahOverviews);
        }
    }
}
