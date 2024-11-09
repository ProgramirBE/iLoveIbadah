using IbadahLover.Application.DTOs.UserActivity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserActivities.Requests.Queries
{
    public class GetUserActivityListRequest : IRequest<List<UserActivityListDto>>
    {
    }
}
