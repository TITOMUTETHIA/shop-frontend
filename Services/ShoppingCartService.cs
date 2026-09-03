using Microsoft.EntityFrameworkCore;
using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ShoppingCartService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IReadOnlyList<OrderItem>> GetCartItemsAsync(int customerId, CancellationToken cancellationToken = default)
        {
            // OrderId is nullable — cart items are those without an associated order.
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            return await db.OrderItems
                .Include(i => i.Product)
                .Where(i => i.OrderId == null)
                .ToListAsync(cancellationToken);
        }

        public async Task AddToCartAsync(int customerId, ShopProduct product, int quantity, CancellationToken cancellationToken = default)
        {
            var cartItem = new OrderItem
            {
                ProductId = product.Id,
                Quantity = quantity,
                UnitPrice = product.Price
            };

            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            db.OrderItems.Add(cartItem);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveFromCartAsync(int customerId, int productId, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var item = await db.OrderItems
                .FirstOrDefaultAsync(i => i.ProductId == productId && i.OrderId == null, cancellationToken);

            if (item != null)
            {
                db.OrderItems.Remove(item);
                await db.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task ClearCartAsync(int customerId, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var items = await db.OrderItems
                .Where(i => i.OrderId == null)
                .ToListAsync(cancellationToken);

            db.OrderItems.RemoveRange(items);
            await db.SaveChangesAsync(cancellationToken);
        }
    }
}
