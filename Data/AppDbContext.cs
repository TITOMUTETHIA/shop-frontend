using Microsoft.EntityFrameworkCore;
using ShopFrontend.Models;

namespace ShopFrontend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ShopProduct> Products { get; set; } = null!;
    public DbSet<ShopCustomer> Customers { get; set; } = null!;
}
