using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IbadahLover.Identity.Models;

namespace IbadahLover.Identity.Configurations
{
    public class ApplicationUserTokenConfiguration : IEntityTypeConfiguration<ApplicationUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
        {
            builder.ToTable("User_Account_Authentication_Token");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.UserId).HasColumnName("User_Account_id");
            builder.Property(e => e.LoginProvider).HasColumnName("login_provider");
            builder.Property(e => e.Name).HasColumnName("unique_id");
            builder.Property(e => e.Value).HasColumnName("jwt_value");
        }
    }
}
