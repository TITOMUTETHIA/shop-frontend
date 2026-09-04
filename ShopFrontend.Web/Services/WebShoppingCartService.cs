using ShopFrontend.Models;
using ShopFrontend.Services;

namespace ShopFrontend.Web.Services;

public class WebShoppingCartService : IShoppingCartService
{
    private readonly List<OrderItem> _items = new();

    public Task<IReadOnlyList<OrderItem>> GetCartItemsAsync(int customerId, CancellationToken cancellationToken = default)
    {
        return Task.FromResult((IReadOnlyList<OrderItem>)_items.Where(i => i.OrderId == null).ToList());
    }

    public Task AddToCartAsync(int customerId, ShopProduct product, int quantity, CancellationToken cancellationToken = default)
    {
        _items.Add(new OrderItem { ProductId = product.Id, Quantity = quantity, UnitPrice = product.Price });
        return Task.CompletedTask;
    }

    public Task RemoveFromCartAsync(int customerId, int productId, CancellationToken cancellationToken = default)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId && i.OrderId == null);
        if (item != null) _items.Remove(item);
        return Task.CompletedTask;
    }

    public Task ClearCartAsync(int customerId, CancellationToken cancellationToken = default)
    {
        _items.RemoveAll(i => i.OrderId == null);
        return Task.CompletedTask;
    }
}
