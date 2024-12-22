using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IbadahLover.Domain;
using IbadahLover.Persistence.Enums;
using Microsoft.IdentityModel.Logging;
using IbadahLover.Persistence.Configurations.Entities;

namespace IbadahLover.Persistence
{
    public class IbadahLoverDbContext : DbContext
    {
        public IbadahLoverDbContext(DbContextOptions<IbadahLoverDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new DhikrTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SalahTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProfilePictureTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleTypePermissionTypeMappingConfiguration());
            modelBuilder.ApplyConfiguration(new BlobFileConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountRoleTypeMappingConfiguration());
            modelBuilder.ApplyConfiguration(new UserDhikrActivityConfiguration());
            modelBuilder.ApplyConfiguration(new UserSalahActivityConfiguration());
            modelBuilder.ApplyConfiguration(new UserDhikrOverviewConfiguration());
            modelBuilder.ApplyConfiguration(new UserSalahOverviewConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IbadahLoverDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                ActionType actionType = ActionType.Update;

                if (entry.State == EntityState.Added)
                {
                    actionType = ActionType.Create;
                }
                //var logMessage = CreateLogMessage(entry, actionType);
                //LogHelper.Log(logMessage); // Assuming LogHelper has a static Log method
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<BlobFile> BlobFiles { get; set; }
        public DbSet<DhikrType> DhikrTypes { get; set; }
        public DbSet<SalahType> SalahTypes { get; set; }
        public DbSet<ProfilePictureType> ProfilePictureTypes { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<RoleTypePermissionTypeMapping> RoleTypePermissionTypeMappings { get; set; }
        public DbSet<UserAccountRoleTypeMapping> UserAccountRoleTypeMappings { get; set; }
        public DbSet<UserDhikrActivity> UserDhikrActivities { get; set; }
        public DbSet<UserSalahActivity> UserSalahActivities { get; set; }
        public DbSet<UserDhikrOverview> UserDhikrOverviews { get; set; }
        public DbSet<UserSalahOverview> UserSalahOverviews { get; set; }
    }
}
