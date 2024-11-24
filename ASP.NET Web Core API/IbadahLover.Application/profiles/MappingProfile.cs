using AutoMapper;
using IbadahLover.Application.DTOs.DhikrType;
using IbadahLover.Application.DTOs.ProfilePictureType;
using IbadahLover.Application.DTOs.SalahType;
using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.DTOs.UserDhikrActivity;
using IbadahLover.Application.DTOs.UserDhikrOverview;
using IbadahLover.Application.DTOs.UserSalahActivity;
using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.profiles
{
    // Map Entities to Dtos, Application Layer to Domain Layer
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DhikrType, DhikrTypeDto>().ReverseMap();
            CreateMap<SalahType, SalahTypeDto>().ReverseMap();
            CreateMap<ProfilePictureType, ProfilePictureTypeDto>().ReverseMap();
            CreateMap<UserAccount, UserAccountDto>().ReverseMap();
            CreateMap<UserDhikrActivity, UserDhikrActivityDto>().ReverseMap();
            CreateMap<UserDhikrOverview, UserDhikrOverviewDto>().ReverseMap();
            CreateMap<UserSalahActivity, UserSalahActivityDto>().ReverseMap();
            //CreateMap<UserSalahOverview, UserSalahOverviewDto>().ReverseMap();
        }
    }
}
