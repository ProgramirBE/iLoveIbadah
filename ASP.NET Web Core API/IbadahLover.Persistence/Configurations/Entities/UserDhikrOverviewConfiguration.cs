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
    public class UserDhikrOverviewConfiguration : IEntityTypeConfiguration<UserDhikrOverview>
    {
        public void Configure(EntityTypeBuilder<UserDhikrOverview> builder)
        {
            builder.ToTable("User_Dhikr_Overview");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.UserAccountId).HasColumnName("User_Account_id");
            builder.Property(e => e.TotalPerformed).HasColumnName("total_performed");
            builder.Property(e => e.LastPerformedAt)
                .HasColumnName("last_performed_at")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
