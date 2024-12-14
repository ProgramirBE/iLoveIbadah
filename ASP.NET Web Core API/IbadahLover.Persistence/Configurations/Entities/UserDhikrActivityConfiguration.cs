using IbadahLover.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR.Wrappers;

namespace IbadahLover.Persistence.Configurations.Entities
{
    public class UserDhikrActivityConfiguration : IEntityTypeConfiguration<UserDhikrActivity>
    {
        public void Configure(EntityTypeBuilder<UserDhikrActivity> builder)
        {
            builder.ToTable(tb =>
            {
                tb.HasTrigger("Trigger_Increment_User_Dhikr_Overview_total_performed");
                tb.HasTrigger("Trigger_Update_User_Dhikr_Overview_total_performed");
            });
            builder.ToTable("User_Dhikr_Activity");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.UserAccountId).HasColumnName("User_Account_id");
            builder.Property(e => e.DhikrTypeId).HasColumnName("Dhikr_Type_id");
            builder.Property(e => e.PerformedOn)
                .HasColumnName("performed_on")
                .ValueGeneratedOnAddOrUpdate();
            //.HasDefaultValueSql("CONVERT(VARCHAR(10), GETDATE (), 120)");
            builder.Property(e => e.LastPerformedAt)
                .HasColumnName("last_performed_at")
                .ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.TotalPerformed)
                .HasColumnName("total_performed")
                .HasDefaultValue(1);
        }
    }
}
