using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ShopFrontend.Models;

namespace ShopFrontend.Services;

public interface IShopCatalogService
{
    Task<IReadOnlyList<ShopProduct>> GetProductsAsync(CancellationToken cancellationToken = default);
}
