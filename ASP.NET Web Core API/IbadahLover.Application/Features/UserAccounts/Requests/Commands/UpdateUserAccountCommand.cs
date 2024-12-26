using IbadahLover.Application.DTOs.UserAccount;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserAccounts.Requests.Commands
{
    public class UpdateUserAccountCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateUserAccountDto UserAccountDto { get; set; }
        //public UpdateUserAccountEmailConfirmedDto UserAccountEmailConfirmedDto { get; set; }
        public UpdateUserAccountPasswordHashDto UserAccountPasswordHashDto { get; set; }
        public UpdateUserAccountTotalWarningsDto UserAccountTotalWarningsDto { get; set; }
        public UpdateUserAccountIsPermanentlyBannedDto UserAccountIsPermanentlyBannedDto { get; set; }
        public UpdateUserAccountCurrentLocationDto UserAccountCurrentLocationDto { get; set; }

    }
}
