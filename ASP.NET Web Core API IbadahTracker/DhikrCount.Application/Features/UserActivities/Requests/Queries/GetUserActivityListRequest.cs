using DhikrCount.Application.DTOs.UserActivity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.Features.UserActivities.Requests.Queries
{
    public class GetUserActivityListRequest : IRequest<List<UserActivityListDto>>
    {
    }
}
