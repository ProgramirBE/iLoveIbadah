using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection CongfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IbadahLoverDbContext>(options =>
            {
                //options.UseSqlServer(configuration.GetConnectionString("localConnectionString")); // When Running Locally localdb
                //options.UseSqlServer(configuration.GetConnectionString("azuresqlserverconnectionstring")); // When Running Locally azuresqlserver db
                options.UseSqlServer(configuration.GetSection("azuresqlserverconnectionstring").Value); // When Deployed to Azure
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IUserSalahActivityRepository, UserSalahActivityRepository>();
            services.AddScoped<IUserSalahOverviewRepository, UserSalahOverviewRepository>();
            services.AddScoped<IUserDhikrActivityRepository, UserDhikrActivityRepository>();
            services.AddScoped<IUserDhikrOverviewRepository, UserDhikrOverviewRepository>();
            services.AddScoped<ISalahTypeRepository, SalahTypeRepository>();
            services.AddScoped<IDhikrTypeRepository, DhikrTypeRepository>();
            services.AddScoped<IProfilePictureTypeRepository, ProfilePictureTypeRepository>();
            services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
            services.AddScoped<IRoleTypeRepository, RoleTypeRepository>();
            services.AddScoped<IBlobFileRepository, BlobFileRepository>();
            services.AddScoped<IUserAccountRoleTypeMappingRepository, UserAccountRoleTypeMappingRepository>();
            services.AddScoped<IRoleTypePermissionTypeMappingRepository, RoleTypePermissionTypeMappingRepository>();

            return services;
        }
    }
}
