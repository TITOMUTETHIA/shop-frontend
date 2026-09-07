using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ShopFrontend.Models;

namespace ShopFrontend.Services;

public interface IShoppingCartService
{
    Task AddToCartAsync(ShopProduct product, int quantity = 1, CancellationToken cancellationToken = default);
    Task RemoveFromCartAsync(int productId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ShopProduct>> GetCartItemsAsync(CancellationToken cancellationToken = default);
}
