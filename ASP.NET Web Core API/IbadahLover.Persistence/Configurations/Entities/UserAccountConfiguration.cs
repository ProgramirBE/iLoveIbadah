using IbadahLover.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Persistence.Configurations.Entities
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable("User_Account");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.FullName).HasColumnName("full_name");
            builder.Property(e => e.Email).HasColumnName("email");
            builder.Property(e => e.ProfilePictureTypeId).HasColumnName("Profile_Picture_Type_id");
            builder.Property(e => e.PasswordHash).HasColumnName("password_hash");
            builder.Property(e => e.OAuthProvider).HasColumnName("oauth_provider");
            builder.Property(e => e.OAuthId).HasColumnName("oauth_id");
            builder.Property(e => e.CurrentLongitude).HasColumnName("current_longitude");
            builder.Property(e => e.CurrentLatitude).HasColumnName("current_latitude");
            builder.Property(e => e.TotalWarnings).HasColumnName("total_warnings");
            builder.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed");
            builder.Property(e => e.IsPermanentlyBanned).HasColumnName("is_permanently_banned");
        }
    }
}
