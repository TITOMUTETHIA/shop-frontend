using ShopFrontend.Models;
using ShopFrontend.Services;

namespace ShopFrontend.Web.Services;

public class WebShopOrderService : IShopOrderService
{
    private readonly List<ShopOrder> _orders = new();

    public Task<IReadOnlyList<ShopOrder>> GetOrdersAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult((IReadOnlyList<ShopOrder>)_orders.ToList());
    }

    public Task<ShopOrder?> GetOrderByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));
    }

    public Task AddOrderAsync(ShopOrder order, CancellationToken cancellationToken = default)
    {
        _orders.Add(order);
        return Task.CompletedTask;
    }

    public Task UpdateOrderAsync(ShopOrder order, CancellationToken cancellationToken = default)
    {
        var idx = _orders.FindIndex(o => o.Id == order.Id);
        if (idx >= 0) _orders[idx] = order;
        return Task.CompletedTask;
    }

    public Task DeleteOrderAsync(int id, CancellationToken cancellationToken = default)
    {
        _orders.RemoveAll(o => o.Id == id);
        return Task.CompletedTask;
    }
}
