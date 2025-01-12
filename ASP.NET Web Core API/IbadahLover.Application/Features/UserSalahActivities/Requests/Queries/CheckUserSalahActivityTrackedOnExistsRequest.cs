using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserSalahActivities.Requests.Queries
{
    public class CheckUserSalahActivityTrackedOnExistsRequest : IRequest<bool>
    {
        public int? UserAccountId { get; set; }
        public int SalahTypeId { get; set; }
        public DateTime TrackedOn { get; set; }
    }
}
