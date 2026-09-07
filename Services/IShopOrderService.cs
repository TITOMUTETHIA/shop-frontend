using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ShopFrontend.Models;

namespace ShopFrontend.Services;

public interface IShopOrderService
{
    Task PlaceOrderAsync(ShopCustomer customer, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<object>> GetOrdersAsync(CancellationToken cancellationToken = default);
}
