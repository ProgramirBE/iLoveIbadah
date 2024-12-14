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
    public class UserSalahActivityConfiguration : IEntityTypeConfiguration<UserSalahActivity>
    {
        public void Configure(EntityTypeBuilder<UserSalahActivity> builder)
        {
            builder.ToTable(tb =>
            {
                tb.HasTrigger("Trigger_Update_User_Salah_Overview_total_tracked");
            });
            builder.ToTable("User_Salah_Activity");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.UserAccountId).HasColumnName("User_Account_id");
            builder.Property(e => e.SalahTypeId).HasColumnName("Salah_Type_id");
            builder.Property(e => e.TrackedOn)
                .HasColumnName("tracked_on")
                .ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.PunctualityPercentage).HasColumnName("punctuality_percentage");
        }
    }
}
