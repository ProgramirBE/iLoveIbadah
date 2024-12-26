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
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
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
            builder.Property(e => e.UserName).HasColumnName("unique_id");
            builder.Property(e => e.NormalizedUserName).HasColumnName("normalized_unique_id");
            builder.Property(e => e.Email).HasColumnName("email");
            builder.Property(e => e.NormalizedEmail).HasColumnName("normalized_email");
            builder.Property(e => e.PasswordHash).HasColumnName("password_hash");
            builder.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed");
            builder.Property(e => e.ConcurrencyStamp).HasColumnName("concurrency_stamp");
            builder.Property(e => e.SecurityStamp).HasColumnName("security_stamp");
            //builder.Property(e => e.UniqueId).HasColumnName("unique_id");
            //builder.Property(e => e.ProfilePictureTypeId).HasColumnName("profile_picture_type_id");
            //builder.Property(e => e.CurrentLocation).HasColumnName("current_location");
            //builder.Property(e => e.TotalWarnings).HasColumnName("total_warnings");
            //builder.Property(e => e.IsPermanentlyBanned).HasColumnName("is_permanently_banned");
        }
    }
}
