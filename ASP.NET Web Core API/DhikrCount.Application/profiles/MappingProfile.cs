using AutoMapper;
using DhikrCount.Application.DTOs.DhikrType;
using DhikrCount.Application.DTOs.UserAccount;
using DhikrCount.Application.DTOs.UserActivity;
using DhikrCount.Application.DTOs.UserDhikrCount;
using DhikrCount.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.profiles
{
    // Map Entities to Dtos, Application Layer to Domain Layer
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DhikrType, DhikrTypeDto>().ReverseMap();
            CreateMap<UserAccount, UserAccountDto>().ReverseMap();
            CreateMap<UserActivity, UserActivityDto>().ReverseMap();
            CreateMap<UserDhikrCount, UserDhikrCountDto>().ReverseMap();
        }
    }
}
