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
    public class ProfilePictureTypeConfiguration : IEntityTypeConfiguration<ProfilePictureType>
    {
        public void Configure(EntityTypeBuilder<ProfilePictureType> builder)
        {
            builder.ToTable("Profile_Picture_Type");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.BlobFileId).HasColumnName("Blob_File_id");
            builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        }
    }
}
