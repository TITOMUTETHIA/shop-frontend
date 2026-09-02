using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public interface IShoppingCartService
    {
        Task<IReadOnlyList<OrderItem>> GetCartItemsAsync(int customerId, CancellationToken cancellationToken = default);
        Task AddToCartAsync(int customerId, ShopProduct product, int quantity, CancellationToken cancellationToken = default);
        Task RemoveFromCartAsync(int customerId, int productId, CancellationToken cancellationToken = default);
        Task ClearCartAsync(int customerId, CancellationToken cancellationToken = default);
    }
}
