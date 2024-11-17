using IbadahLover.Application.DTOs.UserDhikrActivity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrActivities.Requests.Queries
{
    // Application User Request to get Details of User Activity
    public class GetUserDhikrActivityDetailsRequest : IRequest<UserDhikrActivityDto>
    {
        public int Id { get; }
        public int UserAccountId { get; set; }

        public int DhikrTypeId { get; set; }
        public DateTime PerformedAt { get; set; }
        public int TotalDhikrPerformed { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public int LastModifiedBy { get; set; }
    }
}
