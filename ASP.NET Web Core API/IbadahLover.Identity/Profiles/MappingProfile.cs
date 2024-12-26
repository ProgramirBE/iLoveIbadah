using AutoMapper;
using IbadahLover.Application.DTOs.BlobFile;
using IbadahLover.Application.Models.Identity;
using IbadahLover.Domain;
using IbadahLover.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Identity.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserAccount>().ReverseMap();
            CreateMap<ApplicationRole, RoleType>().ReverseMap();
            CreateMap<ApplicationUserRole, UserAccountRoleTypeMapping>().ReverseMap();
            CreateMap<ApplicationUserClaim, UserAccountClaimTypeMapping>().ReverseMap();
            CreateMap<ApplicationRoleClaim, RoleTypeClaimTypeMapping>().ReverseMap();
            CreateMap<ApplicationUserToken, UserAccountAuthenticationToken>().ReverseMap();
            CreateMap<ApplicationUserLogin, UserAccountExternalLogin>().ReverseMap();
        }
    }
}
