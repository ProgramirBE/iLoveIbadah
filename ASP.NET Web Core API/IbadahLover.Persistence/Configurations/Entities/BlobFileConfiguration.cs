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
    public class BlobFileConfiguration : IEntityTypeConfiguration<BlobFile>
    {
        public void Configure(EntityTypeBuilder<BlobFile> builder)
        {
            builder.ToTable("Blob_File");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Uri).HasColumnName("uri");
            builder.Property(e => e.FullName).HasColumnName("full_name");
            builder.Property(e => e.Extension).HasColumnName("extension");
            builder.Property(e => e.Size).HasColumnName("size")
                .HasDefaultValue(null);
            builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        }
    }
}
