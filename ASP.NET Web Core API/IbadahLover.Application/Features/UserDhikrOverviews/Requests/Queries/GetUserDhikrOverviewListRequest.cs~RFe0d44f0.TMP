using IbadahLover.Application.DTOs.UserDhikrOverview;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrOverviews.Requests.Queries
{
    public class GetUserDhikrOverviewListRequest : IRequest<List<UserDhikrOverviewDto>>
    {
        public int UserAccountId { get; set; }
        public int DhikrTypeId { get; set; }
        public int TotalPerformed { get; set; }
    }
}
