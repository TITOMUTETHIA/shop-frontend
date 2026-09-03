using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public interface IOrderService
    {
        Task<IReadOnlyList<Order>> GetOrdersAsync(CancellationToken cancellationToken = default);
        Task<Order?> GetOrderByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddOrderAsync(Order order, CancellationToken cancellationToken = default);
        Task UpdateOrderAsync(Order order, CancellationToken cancellationToken = default);
        Task DeleteOrderAsync(int id, CancellationToken cancellationToken = default);
    }
}
