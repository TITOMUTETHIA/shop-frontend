using System.Threading;
using System.Threading.Tasks;
using ShopFrontend.Models;

namespace ShopFrontend.Services;

public sealed class LocalShopCustomerService : IShopCustomerService
{
    private ShopCustomer? _current;

    public Task<ShopCustomer?> GetCurrentCustomerAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_current);

    public Task SetCurrentCustomerAsync(ShopCustomer customer, CancellationToken cancellationToken = default)
    {
        _current = customer;
        return Task.CompletedTask;
    }
}
