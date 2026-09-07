using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ShopFrontend.Models;

namespace ShopFrontend.Services;

public sealed class LocalShoppingCartService : IShoppingCartService
{
    private readonly List<ShopProduct> _items = new();

    public Task AddToCartAsync(ShopProduct product, int quantity = 1, CancellationToken cancellationToken = default)
    {
        for (int i = 0; i < quantity; i++) _items.Add(product);
        return Task.CompletedTask;
    }

    public Task RemoveFromCartAsync(int productId, CancellationToken cancellationToken = default)
    {
        var idx = _items.FindIndex(p => p.Id == productId);
        if (idx >= 0) _items.RemoveAt(idx);
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<ShopProduct>> GetCartItemsAsync(CancellationToken cancellationToken = default)
        => Task.FromResult((IReadOnlyList<ShopProduct>)_items.ToList());
}
