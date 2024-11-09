using DhikrCount.Application.DTOs.UserAccount;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.Features.UserAccounts.Requests.Commands
{
    public class CreateUserAccountCommand : IRequest<int>
    {
        public UserAccountDto UserAccountDto { get; set; }
    }
}
