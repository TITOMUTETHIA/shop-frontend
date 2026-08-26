using ShopFrontend.Models;

namespace ShopFrontend.Services;

public interface IShopCatalogService
{
    Task<IReadOnlyList<ShopProduct>> GetProductsAsync(CancellationToken cancellationToken = default);
}
