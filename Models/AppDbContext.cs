using Microsoft.EntityFrameworkCore;

namespace ShopFrontend.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ShopCustomer> Customers { get; set; }
    public DbSet<ShopProduct> Products { get; set; }
    public DbSet<ShopOrder> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}
