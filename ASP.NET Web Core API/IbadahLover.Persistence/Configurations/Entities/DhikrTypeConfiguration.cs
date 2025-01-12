using IbadahLover.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Persistence.Configurations.Entities
{
    public class DhikrTypeConfiguration : IEntityTypeConfiguration<DhikrType>
    {
        public void Configure(EntityTypeBuilder<DhikrType> builder)
        {
            builder.ToTable("Dhikr_Type");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.FullName).HasColumnName("full_name");
            builder.Property(e => e.CreatedBy).HasColumnName("created_by");
            builder.Property(e => e.ArabicFullName).HasColumnName("arabic_full_name");
        }
    }
}
