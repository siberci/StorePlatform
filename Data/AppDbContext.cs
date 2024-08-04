using Microsoft.EntityFrameworkCore;
using StorePIatform.Models;
using StorePlatform.Models;

namespace StorePIatform.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUserViewModel> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserViewModel>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
