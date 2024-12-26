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
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("Role_Type");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name).HasColumnName("full_name");
            //builder.Property(e => e.Details).HasColumnName("details");

            //builder.HasData(
            //    new IdentityRole
            //    {
            //        Id = "1",
            //        Name = "Admin",
            //        NormalizedName = "ADMIN"
            //    },
            //    new IdentityRole
            //    {
            //        Id = "2",
            //        Name = "User",
            //        NormalizedName = "USER"
            //    }
            //);
        }
    }
}
