using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserAccounts.Requests.Commands
{
    public class CreateUserAccountCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserAccountDto UserAccountDto { get; set; }
    }
}
