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
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.ToTable("User_Account_Role_Type_Mappings");
            //builder.Property<int>("Id").HasColumnName("id").ValueGeneratedOnAdd();
            //builder.HasKey("Id");
            //builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.RoleId).HasColumnName("Role_Type_id");
            builder.Property(e => e.UserId).HasColumnName("User_Account_id");
        }
    }
}
