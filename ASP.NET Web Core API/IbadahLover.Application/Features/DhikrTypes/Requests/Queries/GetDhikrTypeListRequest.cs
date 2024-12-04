using IbadahLover.Application.DTOs.DhikrType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.DhikrTypes.Requests.Queries
{
    public class GetDhikrTypeListRequest : IRequest<List<DhikrTypeListDto>>
    {
        public string FullName { get; set; }
        public int CreatedBy { get; set; }
    }
}
