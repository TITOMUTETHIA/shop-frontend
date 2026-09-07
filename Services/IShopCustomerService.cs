using System.Threading;
using System.Threading.Tasks;
using ShopFrontend.Models;

namespace ShopFrontend.Services;

public interface IShopCustomerService
{
    Task<ShopCustomer?> GetCurrentCustomerAsync(CancellationToken cancellationToken = default);
    Task SetCurrentCustomerAsync(ShopCustomer customer, CancellationToken cancellationToken = default);
}
