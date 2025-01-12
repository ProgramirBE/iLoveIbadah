using AutoMapper;
using IbadahLover.Application.DTOs.BlobFile;
using IbadahLover.Application.DTOs.DhikrType;
using IbadahLover.Application.DTOs.PermissionType;
using IbadahLover.Application.DTOs.ProfilePictureType;
using IbadahLover.Application.DTOs.RoleType;
using IbadahLover.Application.DTOs.RoleTypePermissionTypeMapping;
using IbadahLover.Application.DTOs.SalahType;
using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.DTOs.UserAccountRoleTypeMapping;
using IbadahLover.Application.DTOs.UserDhikrActivity;
using IbadahLover.Application.DTOs.UserDhikrOverview;
using IbadahLover.Application.DTOs.UserSalahActivity;
using IbadahLover.Application.DTOs.UserSalahOverview;
using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Profiles
{
    // Map Entities to Dtos, Application Layer to Domain Layer
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlobFile, BlobFileDto>().ReverseMap();
            CreateMap<BlobFile, BlobFileListDto>().ReverseMap();
            CreateMap<BlobFile, CreateBlobFileDto>().ReverseMap();
            CreateMap<DhikrType, DhikrTypeListDto>().ReverseMap();
            CreateMap<DhikrType, DhikrTypeDto>().ReverseMap();
            CreateMap<DhikrType, CreateDhikrTypeDto>().ReverseMap();
            CreateMap<DhikrType, DhikrTypeByUserAccountListDto>().ReverseMap();
            CreateMap<SalahType, SalahTypeDto>().ReverseMap();
            CreateMap<SalahType, SalahTypeListDto>().ReverseMap();
            CreateMap<ProfilePictureType, ProfilePictureTypeDto>().ReverseMap();
            CreateMap<ProfilePictureType, ProfilePictureTypeListDto>().ReverseMap();
            CreateMap<RoleType, RoleTypeDto>().ReverseMap();
            CreateMap<RoleType, RoleTypeListDto>().ReverseMap();
            CreateMap<PermissionType, PermissionTypeDto>().ReverseMap();
            CreateMap<PermissionType, PermissionTypeListDto>().ReverseMap();
            CreateMap<RoleTypePermissionTypeMapping, RoleTypePermissionTypeMappingDto>().ReverseMap();
            CreateMap<RoleTypePermissionTypeMapping, RoleTypePermissionTypeMappingListDto>().ReverseMap();
            CreateMap<UserAccount, UserAccountDto>().ReverseMap();
            CreateMap<UserAccount, UserAccountListDto>().ReverseMap();
            CreateMap<UserAccount, CreateUserAccountDto>().ReverseMap();
            CreateMap<UserAccount, UpdateUserAccountDto>().ReverseMap();
            CreateMap<UserAccount, UpdateUserAccountCurrentLocationDto>().ReverseMap();
            CreateMap<UserAccount, UpdateUserAccountEmailConfirmedDto>().ReverseMap();
            CreateMap<UserAccount, UpdateUserAccountIsPermanentlyBannedDto>().ReverseMap();
            CreateMap<UserAccount, UpdateUserAccountPasswordHashDto>().ReverseMap();
            CreateMap<UserAccount, UpdateUserAccountTotalWarningsDto>().ReverseMap();
            CreateMap<UserAccountRoleTypeMapping, UserAccountRoleTypeMappingDto>().ReverseMap();
            CreateMap<UserAccountRoleTypeMapping, UserAccountRoleTypeMappingListDto>().ReverseMap();
            CreateMap<UserDhikrActivity, UserDhikrActivityDto>().ReverseMap();
            CreateMap<UserDhikrActivity, UserDhikrActivityListDto>().ReverseMap();
            CreateMap<UserDhikrActivity, CreateUserDhikrActivityDto>().ReverseMap();
            CreateMap<UserDhikrActivity, UpdateUserDhikrActivityDto>().ReverseMap();
            CreateMap<UserDhikrOverview, UserDhikrOverviewDto>().ReverseMap();
            CreateMap<UserDhikrOverview, UserDhikrOverviewListDto>().ReverseMap();
            CreateMap<UserDhikrActivity, UserDhikrActivityByPerformedOnDto>().ReverseMap();
            CreateMap<UserSalahActivity, UserSalahActivityListDto>().ReverseMap();
            CreateMap<UserSalahActivity, UserSalahActivityListByTrackedOnDto>().ReverseMap();
            CreateMap<UserSalahActivity, UserSalahActivityDto>().ReverseMap();
            CreateMap<UserSalahActivity, CreateUserSalahActivityDto>().ReverseMap();
            CreateMap<UserSalahActivity, UpdateUserSalahActivityDto>().ReverseMap();
            CreateMap<UserSalahOverview, UserSalahOverviewDto>().ReverseMap();
            CreateMap<UserSalahOverview, UserSalahOverviewListDto>().ReverseMap();
        }
    }
}
