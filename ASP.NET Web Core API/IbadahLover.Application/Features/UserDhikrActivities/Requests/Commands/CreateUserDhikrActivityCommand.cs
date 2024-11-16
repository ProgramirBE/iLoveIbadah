using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.DTOs.UserDhikrActivity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserActivities.Requests.Commands
{
    public class CreateUserDhikrActivityCommand : IRequest<int>
    {
        public UserDhikrActivityDto UserDhikrActivityDto { get; set; }
    }
}
