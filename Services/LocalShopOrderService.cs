using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ShopFrontend.Models;

namespace ShopFrontend.Services;

public sealed class LocalShopOrderService : IShopOrderService
{
    private readonly List<object> _orders = new();

    public Task PlaceOrderAsync(ShopCustomer customer, CancellationToken cancellationToken = default)
    {
        _orders.Add(new { Customer = customer });
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<object>> GetOrdersAsync(CancellationToken cancellationToken = default)
        => Task.FromResult((IReadOnlyList<object>)_orders);
}
