using IbadahLover.Application.DTOs.UserActivity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserActivities.Requests.Commands
{
    public class UpdateUserActivityCommand : IRequest<Unit>
    {
        public UpdateUserActivityDto UserActivityDto { get; set; }
    }
}
