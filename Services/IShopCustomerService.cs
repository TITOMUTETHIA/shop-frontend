using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public interface IShopCustomerService
    {
        Task<IReadOnlyList<ShopCustomer>> GetCustomersAsync(CancellationToken cancellationToken = default);
        Task<ShopCustomer?> GetCustomerByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddCustomerAsync(ShopCustomer customer, CancellationToken cancellationToken = default);
        Task UpdateCustomerAsync(ShopCustomer customer, CancellationToken cancellationToken = default);
        Task DeleteCustomerAsync(int id, CancellationToken cancellationToken = default);
    }
}
