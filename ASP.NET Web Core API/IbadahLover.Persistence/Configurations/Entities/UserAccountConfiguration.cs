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
            builder.ToTable(tb =>
            {
                tb.HasTrigger("Trigger_Update_User_Account_is_permanently_banned");
                tb.HasTrigger("Trigger_Create_User_Salah_Overview");
                tb.HasTrigger("Trigger_Create_User_Dhikr_Overview");
                tb.HasTrigger("Trigger_Create_User_Account_Role_Type_Mapping");
            });
            builder.ToTable("User_Account");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.FullName).HasColumnName("full_name");
            builder.Property(e => e.UniqueId).HasColumnName("unique_id");
            builder.Property(e => e.NormalizedUniqueId).HasColumnName("normalized_unique_id");
            builder.Property(e => e.Email).HasColumnName("email");
            builder.Property(e => e.NormalizedEmail).HasColumnName("normalized_email");
            builder.Property(e => e.ProfilePictureTypeId)
                .HasColumnName("Profile_Picture_Type_id")
                .HasDefaultValue(1);
            builder.Property(e => e.PasswordHash).HasColumnName("password_hash");
            //builder.Property(e => e.OAuthProvider).HasColumnName("oauth_provider");
            //builder.Property(e => e.OAuthId).HasColumnName("oauth_id");
            //builder.Property(e => e.CurrentLongitude).HasColumnName("current_longitude");
            //builder.Property(e => e.CurrentLatitude).HasColumnName("current_latitude");
            builder.Property(e => e.CurrentLocation).HasColumnName("current_location");
            builder.Property(e => e.TotalWarnings)
                .HasColumnName("total_warnings")
                .HasDefaultValue(0);
            builder.Property(e => e.EmailConfirmed)
                .HasColumnName("email_confirmed")
                .HasDefaultValue(false);
            builder.Property(e => e.IsPermanentlyBanned)
                .HasColumnName("is_permanently_banned")
                .HasDefaultValue(false);
            builder.Property(e => e.ConcurrencyStamp).HasColumnName("concurrency_stamp");
            builder.Property(e => e.SecurityStamp).HasColumnName("security_stamp");
        }
    }
}
