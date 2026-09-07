using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ShopFrontend.Models;

namespace ShopFrontend.Services;

public sealed class LocalShopProductService : IShopProductService
{
    private static readonly List<ShopProduct> _products = new()
    {
        new ShopProduct { Id = 1, Name = "Avocado", Price = 1.49m, Stock = 10, Category = "Produce" },
        new ShopProduct { Id = 2, Name = "Sourdough loaf", Price = 4.50m, Stock = 5, Category = "Bakery" }
    };

    public Task<IReadOnlyList<ShopProduct>> GetProductsAsync(CancellationToken cancellationToken = default)
        => Task.FromResult((IReadOnlyList<ShopProduct>)_products);

    public Task<ShopProduct?> GetProductAsync(int id, CancellationToken cancellationToken = default)
        => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
}
