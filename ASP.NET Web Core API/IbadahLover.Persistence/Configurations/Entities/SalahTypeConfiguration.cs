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
    public class SalahTypeConfiguration : IEntityTypeConfiguration<SalahType>
    {
        public void Configure(EntityTypeBuilder<SalahType> builder)
        {
            builder.ToTable("Salah_Type");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.FullName).HasColumnName("full_name");
            builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        }
    }
}
