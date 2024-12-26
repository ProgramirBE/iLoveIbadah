using IbadahLover.Application.DTOs.UserAccount;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserAccounts.Requests.Queries
{
    // Application User Request to get a List of User Account
    public class GetUserAccountListRequest : IRequest<List<UserAccountListDto>>
    {
        public string FullName { get; set; }
        public string UniqueId { get; set; }
        public int? ProfilePictureTypeId { get; set; }
        //[Column(TypeName = "decimal(11, 8)")]
        //public decimal? CurrentLongitude { get; set; }
        //[Column(TypeName = "decimal(10, 8)")]
        //public decimal? CurrentLatitude { get; set; } // Maybe leaderboards bassed on continent filtering option? asia, europe, africa, etc
        public string? CurrentLocation { get; set; } // city only
        public bool? IsPermanentlyBanned { get; set; } // to filter out permanently banned users from leaderboards! if he has a bad username and is banned he wil else still appear on leaderboard except if I delete the profile, but maybe he will contact support and justify so now he lost his account. so just ban and block acces to using app logged in!
    }
}
