using IbadahLover.Application.DTOs.UserAccount;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserAccounts.Requests.Queries
{
    // Application User Request to get a List of User Account
    public class GetUserAccountListRequest : IRequest<List<UserAccountListDto>>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
