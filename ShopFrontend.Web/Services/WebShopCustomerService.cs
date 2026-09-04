using ShopFrontend.Models;
using ShopFrontend.Services;

namespace ShopFrontend.Web.Services;

public class WebShopCustomerService : IShopCustomerService
{
    private readonly List<ShopCustomer> _customers = new();

    public Task<IReadOnlyList<ShopCustomer>> GetCustomersAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult((IReadOnlyList<ShopCustomer>)_customers.ToList());
    }

    public Task<ShopCustomer?> GetCustomerByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_customers.FirstOrDefault(c => c.Id == id));
    }

    public Task AddCustomerAsync(ShopCustomer customer, CancellationToken cancellationToken = default)
    {
        _customers.Add(customer);
        return Task.CompletedTask;
    }

    public Task UpdateCustomerAsync(ShopCustomer customer, CancellationToken cancellationToken = default)
    {
        var idx = _customers.FindIndex(c => c.Id == customer.Id);
        if (idx >= 0) _customers[idx] = customer;
        return Task.CompletedTask;
    }

    public Task DeleteCustomerAsync(int id, CancellationToken cancellationToken = default)
    {
        _customers.RemoveAll(c => c.Id == id);
        return Task.CompletedTask;
    }
}
