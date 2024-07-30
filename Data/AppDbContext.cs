using Microsoft.EntityFrameworkCore;
using StorePIatform.Models;

namespace StorePIatform.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<LoginViewModel> Login { get; set; }
        public DbSet<RegisterViewModel> Register { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the LoginViewModel entity
            modelBuilder.Entity<LoginViewModel>(entity =>
            {
                entity.ToTable("Login");
                entity.HasKey(e => e.Id);
            });

            // Configure the RegisterViewModel entity
            modelBuilder.Entity<RegisterViewModel>(entity =>
            {
                entity.ToTable("Register");
                entity.HasKey(e => e.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
