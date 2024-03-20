using Core.Models.Entities;
using Domain.Entities;
using Infrastructure.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public partial class WebAppContext : DbContext
    {

        public WebAppContext(DbContextOptions<WebAppContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = 0;

                        entry.Entity.UpdatedDate = DateTime.Now;
                        entry.Entity.UpdatedBy = 0;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.Now;
                        entry.Entity.UpdatedBy = 0;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
