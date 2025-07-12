using HelloWorldAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldAPI
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var CreatedTime = new DateTime(2025, 5, 27, 4, 13, 7, 141, DateTimeKind.Utc).AddTicks(2842);

            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Number = "Order-1", Name = "Order 1", Qty = 2, Price = 20.5f, CreateAt = CreatedTime },
                new Order { Id = 2, Number = "Order-2", Name = "Order 2", Qty = 1, Price = 15.0f, CreateAt = CreatedTime },
                new Order { Id = 3, Number = "Order-3", Name = "Order 3", Qty = 5, Price = 50.0f , CreateAt = CreatedTime }
            );
        }
    }
}
