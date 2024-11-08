using DhikrCount.Application.DTOs.UserAccount;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.Features.UserAccounts.Requests.Commands
{
    public class UpdateUserAccountCommand : IRequest<Unit>
    {
        public UpdateUserAccountDto UserAccountDto { get; set; }
    }
}
