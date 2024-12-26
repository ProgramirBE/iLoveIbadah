using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IbadahLover.Identity.Models;

namespace IbadahLover.Identity.Configurations
{
    public class ApplicationRoleClaimConfiguration : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder.ToTable("Role_Type_Claim_Type_Mapping");
            //builder.Property<int>("Id").HasColumnName("id").ValueGeneratedOnAdd();
            //builder.HasKey("Id");
            //builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.RoleId).HasColumnName("Role_Type_id");
            builder.Property(e => e.ClaimType).HasColumnName("claim_type");
            builder.Property(e => e.ClaimValue).HasColumnName("claim_value");
        }
    }
}
