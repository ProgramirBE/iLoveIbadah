using IbadahLover.Application.DTOs.UserDhikrActivity;
using IbadahLover.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrActivities.Requests.Commands
{
    public class CreateUserDhikrActivityCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserDhikrActivityDto UserDhikrActivityDto { get; set; }
    }
}
