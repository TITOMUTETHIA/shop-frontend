using Microsoft.EntityFrameworkCore;
using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public class ShopCustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public ShopCustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Customer>> GetCustomersAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Customers.ToListAsync(cancellationToken);
        }

        public async Task<ShopCustomer?> GetCustomerByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCustomerAsync(int id, CancellationToken cancellationToken = default)
        {
            var customer = await _context.Customers.FindAsync(new object[] { id }, cancellationToken);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
