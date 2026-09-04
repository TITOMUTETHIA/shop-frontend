using Microsoft.EntityFrameworkCore;
using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public class ShopProductService : IShopProductService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ShopProductService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IReadOnlyList<ShopProduct>> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            return await db.Products.ToListAsync(cancellationToken);
        }

        public async Task<ShopProduct?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            return await db.Products.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task AddProductAsync(ShopProduct product, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            db.Products.Add(product);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateProductAsync(ShopProduct product, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            db.Products.Update(product);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProductAsync(int id, CancellationToken cancellationToken = default)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var product = await db.Products.FindAsync(new object[] { id }, cancellationToken);
            if (product != null)
            {
                db.Products.Remove(product);
                await db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
