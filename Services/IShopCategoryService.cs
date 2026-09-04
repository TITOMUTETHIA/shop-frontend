using ShopFrontend.Models;

namespace ShopFrontend.Services
{
    public interface IShopCategoryService
    {
        Task<IReadOnlyList<string>> GetCategoriesAsync(CancellationToken cancellationToken = default);
    }
}
