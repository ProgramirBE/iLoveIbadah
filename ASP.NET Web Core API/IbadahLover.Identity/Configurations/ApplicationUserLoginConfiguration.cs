using IbadahLover.Identity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Identity.Configurations
{
    public class ApplicationUserLoginConfiguration : IEntityTypeConfiguration<ApplicationUserLogin>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
        {
            builder.ToTable("User_Account_External_Login");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.UserId).HasColumnName("User_Account_id");
            builder.Property(e => e.LoginProvider).HasColumnName("oauth_provider");
            builder.Property(e => e.ProviderKey).HasColumnName("oauth_key");
            builder.Property(e => e.ProviderDisplayName).HasColumnName("oauth_full_name");
        }
    }
}
