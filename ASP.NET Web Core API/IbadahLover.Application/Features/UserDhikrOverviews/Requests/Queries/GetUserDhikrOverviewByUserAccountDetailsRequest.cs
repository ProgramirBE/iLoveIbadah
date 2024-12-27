using IbadahLover.Application.DTOs.UserDhikrOverview;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrOverviews.Requests.Queries
{
    public class GetUserDhikrOverviewByUserAccountDetailsRequest : IRequest<UserDhikrOverviewDto>
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int TotalPerformed { get; set; }
        public DateTime LastPerformedAt { get; set; }
    }
}
