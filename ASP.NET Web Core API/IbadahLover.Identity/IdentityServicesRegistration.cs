using IbadahLover.Application.Models.Identity;
using IbadahLover.Identity.Models;
using IbadahLover.Identity.Services;
using IbadahLover.Infrastructure.IbadahLover.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
// using IbadahLover.Infrastructure.IbadahLover.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IbadahLover.Application.Contracts.Identity;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace IbadahLover.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            var jwtSettingsKey = configuration.GetSection("jwtsettingskey").Value;
            if (string.IsNullOrEmpty(jwtSettingsKey))
            {
                throw new Exception("jwtsettingskey is not configured properly.");
            }

            services.AddDbContext<ILoveIbadahIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetSection("azuresqlserverconnectionstring").Value));
                //b => b.MigrationAssembly(typeof(ILoveIbadahIdentityDbContext).Assembly.FullName))); I don't need migration!

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ILoveIbadahIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>(provider =>
            {
                return new AuthService(provider.GetRequiredService<UserManager<ApplicationUser>>(), provider.GetRequiredService<IOptions<JwtSettings>>(), jwtSettingsKey);
            });
            services.AddTransient<IUserService, UserService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettingsKey))
                    };
                });

            return services;
        }
    }
}
