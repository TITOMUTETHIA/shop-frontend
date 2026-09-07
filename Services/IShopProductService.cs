using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ShopFrontend.Models;

namespace ShopFrontend.Services;

public interface IShopProductService
{
    Task<IReadOnlyList<ShopProduct>> GetProductsAsync(CancellationToken cancellationToken = default);
    Task<ShopProduct?> GetProductAsync(int id, CancellationToken cancellationToken = default);
}
