using IbadahLover.Identity.Models;
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
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.ToTable("User_Account_Role_Type_Mapping");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.RoleId).HasColumnName("Role_Type_id");
            builder.Property(e => e.UserId).HasColumnName("User_Account_id");
        }
    }
}
