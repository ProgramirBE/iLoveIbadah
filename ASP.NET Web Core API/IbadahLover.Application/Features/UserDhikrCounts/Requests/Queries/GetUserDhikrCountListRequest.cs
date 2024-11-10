using IbadahLover.Application.DTOs.UserDhikrCount;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrCounts.Requests.Queries
{
    public class GetUserDhikrCountListRequest : IRequest<List<UserDhikrCountDto>>
    {
        public int UserAccountId { get; set; }
        public int DhikrTypeId { get; set; }
        public int TotalPerformed { get; set; }
    }
}
