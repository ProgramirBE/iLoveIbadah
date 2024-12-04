using IbadahLover.Application.DTOs.RoleType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.RoleTypes.Requests.Queries
{
    public class GetRoleTypeListRequest : IRequest<List<RoleTypeListDto>>
    {
        public string FullName { get; set; }
        public string Details { get; set; }
    }
}
