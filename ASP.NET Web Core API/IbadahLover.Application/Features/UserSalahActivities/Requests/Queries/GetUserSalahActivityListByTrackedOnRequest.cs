using IbadahLover.Application.DTOs.UserSalahActivity;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserSalahActivities.Requests.Queries
{
    public class GetUserSalahActivityListByTrackedOnRequest : IRequest<List<UserSalahActivityListByTrackedOnDto>>
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int SalahTypeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime TrackedOn { get; set; }
        [Column(TypeName = "decimal(4, 2)")]
        public decimal PunctualityPercentage { get; set; }
    }
}
