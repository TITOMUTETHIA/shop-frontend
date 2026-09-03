using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public interface IShopOrderService
    {
        Task<IReadOnlyList<ShopOrder>> GetOrdersAsync(CancellationToken cancellationToken = default);
        Task<ShopOrder?> GetOrderByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddOrderAsync(ShopOrder order, CancellationToken cancellationToken = default);
        Task UpdateOrderAsync(ShopOrder order, CancellationToken cancellationToken = default);
        Task DeleteOrderAsync(int id, CancellationToken cancellationToken = default);
    }
}
