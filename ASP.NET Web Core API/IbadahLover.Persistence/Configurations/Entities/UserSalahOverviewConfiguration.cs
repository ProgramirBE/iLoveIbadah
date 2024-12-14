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
    public class UserSalahOverviewConfiguration : IEntityTypeConfiguration<UserSalahOverview>
    {
        public void Configure(EntityTypeBuilder<UserSalahOverview> builder)
        {
            builder.ToTable("User_Salah_Overview");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.UserAccountId).HasColumnName("User_Account_id");
            builder.Property(e => e.TotalTracked).HasColumnName("total_tracked");
            builder.Property(e => e.LastTrackedAt)
                .HasColumnName("last_tracked_at")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
