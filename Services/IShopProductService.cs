using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public interface IShopProductService
    {
        Task<IReadOnlyList<ShopProduct>> GetProductsAsync(CancellationToken cancellationToken = default);
        Task<ShopProduct?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddProductAsync(ShopProduct product, CancellationToken cancellationToken = default);
        Task UpdateProductAsync(ShopProduct product, CancellationToken cancellationToken = default);
        Task DeleteProductAsync(int id, CancellationToken cancellationToken = default);
    }
}
