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
    public class UserAccountRoleTypeMappingConfiguration : IEntityTypeConfiguration<UserAccountRoleTypeMapping>
    {
        public void Configure(EntityTypeBuilder<UserAccountRoleTypeMapping> builder)
        {
            builder.ToTable("User_Account_Role_Type_Mapping");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.UserAccountId).HasColumnName("User_Account_id");
            builder.Property(e => e.RoleTypeId).HasColumnName("Role_Type_id");
        }
    }
}
