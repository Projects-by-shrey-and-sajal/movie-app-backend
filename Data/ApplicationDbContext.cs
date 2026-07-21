using Microsoft.EntityFrameworkCore;
using MovieBooking.API.Models;

namespace MovieBooking.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasIndex(u => u.Email).IsUnique().HasDatabaseName("UX_Users_Email");
                entity.Property(u => u.FullName).HasMaxLength(200).IsRequired();
                entity.Property(u => u.Email).HasMaxLength(200).IsRequired();
                entity.Property(u => u.PasswordHash).HasMaxLength(512);
                entity.Property(u => u.Role).HasMaxLength(50).IsRequired();
                entity.Property(u => u.IsActive).HasDefaultValue(true);
                entity.Property(u => u.CreatedAtUtc).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Seed initial accounts (passwords/hashes intentionally null; replace with real hashes)
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Customer User", Email = "customer@example.com", PasswordHash = null, Role = "Customer", IsActive = true, CreatedAtUtc = DateTime.UtcNow },
                new User { Id = 2, FullName = "Manager User", Email = "manager@example.com", PasswordHash = null, Role = "Manager", IsActive = true, CreatedAtUtc = DateTime.UtcNow },
                new User { Id = 3, FullName = "Admin User", Email = "admin@example.com", PasswordHash = null, Role = "Admin", IsActive = true, CreatedAtUtc = DateTime.UtcNow }
            );
        }
    }
}
