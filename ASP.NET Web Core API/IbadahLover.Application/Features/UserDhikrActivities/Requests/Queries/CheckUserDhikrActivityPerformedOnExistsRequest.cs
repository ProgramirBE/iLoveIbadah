using IbadahLover.Application.DTOs.UserDhikrActivity;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrActivities.Requests.Queries
{
    public class CheckUserDhikrActivityPerformedOnExistsRequest : IRequest<bool>
    {
        public int UserAccountId { get; set; }
        public int DhikrTypeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime PerformedOn { get; set; }
    }
}
