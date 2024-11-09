using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.DTOs.UserActivity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserActivities.Requests.Commands
{
    public class CreateUserActivityCommand : IRequest<int>
    {
        public UserActivityDto UserActivityDto { get; set; }
    }
}
