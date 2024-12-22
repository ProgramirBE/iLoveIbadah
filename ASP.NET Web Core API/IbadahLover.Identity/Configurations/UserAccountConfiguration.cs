using IbadahLover.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Identity.Configurations
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("User_Account");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.FullName).HasColumnName("full_name");
            builder.Property(e => e.Email).HasColumnName("email");
            builder.Property(e => e.PasswordHash).HasColumnName("password_hash");
            builder.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed");

        }
    }
}
