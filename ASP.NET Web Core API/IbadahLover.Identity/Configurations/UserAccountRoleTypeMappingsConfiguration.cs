using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Identity.Configurations
{
    public class UserAccountRoleTypeMappingsConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.ToTable("User_Account_Role_Type_Mappings");
            builder.Property(e => e.RoleId).HasColumnName("Role_Type_id");
            builder.Property(e => e.UserId).HasColumnName("User_Account_id");
        }
    }
}
