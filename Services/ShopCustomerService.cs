using Microsoft.EntityFrameworkCore;
using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public class ShopCustomerService : IShopCustomerService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ShopCustomerService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IReadOnlyList<ShopCustomer>> GetCustomersAsync(CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            return await db.Customers.ToListAsync(cancellationToken);
        }

        public async Task<ShopCustomer?> GetCustomerByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            return await db.Customers.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task AddCustomerAsync(ShopCustomer customer, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            db.Customers.Add(customer);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCustomerAsync(ShopCustomer customer, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            db.Customers.Update(customer);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCustomerAsync(int id, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var customer = await db.Customers.FindAsync(new object[] { id }, cancellationToken);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                await db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
