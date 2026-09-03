using Microsoft.EntityFrameworkCore;
using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public class ShopOrderService : IShopOrderService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ShopOrderService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IReadOnlyList<ShopOrder>> GetOrdersAsync(CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            return await db.Orders
                .Include(o => o.Customer)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync(cancellationToken);
        }

        public async Task<ShopOrder?> GetOrderByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            return await db.Orders
                .Include(o => o.Customer)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task AddOrderAsync(ShopOrder order, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            db.Orders.Add(order);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateOrderAsync(ShopOrder order, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            db.Orders.Update(order);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteOrderAsync(int id, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var order = await db.Orders.FindAsync(new object[] { id }, cancellationToken);
            if (order != null)
            {
                db.Orders.Remove(order);
                await db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
