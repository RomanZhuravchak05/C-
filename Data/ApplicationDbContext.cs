using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.API.Models;

namespace RestaurantManagementSystem.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<OrderMenuItem> OrderMenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderMenuItem>()
                .HasKey(omi => new { omi.OrderId, omi.MenuItemId });

            modelBuilder.Entity<OrderMenuItem>()
                .HasOne(omi => omi.Order)
                .WithMany(o => o.OrderMenuItems)
                .HasForeignKey(omi => omi.OrderId);

            modelBuilder.Entity<OrderMenuItem>()
                .HasOne(omi => omi.MenuItem)
                .WithMany(m => m.OrderMenuItems)
                .HasForeignKey(omi => omi.MenuItemId);
        }
    }
}
