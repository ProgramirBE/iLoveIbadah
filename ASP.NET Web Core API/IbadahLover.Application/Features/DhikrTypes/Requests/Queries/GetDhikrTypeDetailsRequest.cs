using IbadahLover.Application.DTOs.DhikrType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.DhikrTypes.Requests.Queries
{
    public class GetDhikrTypeDetailsRequest : IRequest<DhikrTypeDto>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        //public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        //public DateTime LastModifiedOn { get; set; }
        //public int LastModifiedBy { get; set; }
    }
}
