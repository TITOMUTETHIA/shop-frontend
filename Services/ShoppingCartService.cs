using Microsoft.EntityFrameworkCore;
using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly AppDbContext _context;

        public ShoppingCartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<OrderItem>> GetCartItemsAsync(int customerId, CancellationToken cancellationToken = default)
        {
            return await _context.OrderItems
                .Include(i => i.Product)
                .Where(i => i.OrderId == null && i.Order.CustomerId == customerId)
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

            _context.OrderItems.Add(cartItem);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveFromCartAsync(int customerId, int productId, CancellationToken cancellationToken = default)
        {
            var item = await _context.OrderItems
                .FirstOrDefaultAsync(i => i.ProductId == productId && i.OrderId == null, cancellationToken);

            if (item != null)
            {
                _context.OrderItems.Remove(item);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task ClearCartAsync(int customerId, CancellationToken cancellationToken = default)
        {
            var items = await _context.OrderItems
                .Where(i => i.OrderId == null && i.Order.CustomerId == customerId)
                .ToListAsync(cancellationToken);

            _context.OrderItems.RemoveRange(items);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
