using System.Net.Http.Json;
using ShopFrontend.Models;

namespace ShopFrontend.Services;

public sealed class ShopCatalogService(HttpClient httpClient) : IShopCatalogService
{
    public async Task<IReadOnlyList<ShopProduct>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<IReadOnlyList<ShopProduct>>("api/products", cancellationToken)
            ?? Array.Empty<ShopProduct>();
    }
}
