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
    public class RoleTypePermissionTypeMappingConfiguration : IEntityTypeConfiguration<RoleTypePermissionTypeMapping>
    {
        public void Configure(EntityTypeBuilder<RoleTypePermissionTypeMapping> builder)
        {
            builder.ToTable("Role_Type_Permission_Type_Mapping");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.RoleTypeId).HasColumnName("Role_Type_id");
            builder.Property(e => e.PermissionTypeId).HasColumnName("Permission_Type_id");
        }
    }
}
