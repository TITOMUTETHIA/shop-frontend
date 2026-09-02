using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public interface IShopCustomerService
    {
        Task<IReadOnlyList<ShopCustomer>> GetCustomersAsync(CancellationToken cancellationToken = default);
        Task<Customer?> GetCustomerByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken = default);
        Task UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken = default);
        Task DeleteCustomerAsync(int id, CancellationToken cancellationToken = default);
    }
}
