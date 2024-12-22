using IbadahLover.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IbadahLover.Identity.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Infrastructure.IbadahLover.Identity
{
    public class ILoveIbadahIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ILoveIbadahIdentityDbContext(DbContextOptions<ILoveIbadahIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountRoleTypeMappingsConfiguration());
        }
    }
}
