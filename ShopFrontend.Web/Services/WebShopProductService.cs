using System.Net.Http.Json;
using ShopFrontend.Models;
using ShopFrontend.Services;

namespace ShopFrontend.Web.Services;

public class WebShopProductService : IShopProductService
{
    private readonly HttpClient _http;

    public WebShopProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IReadOnlyList<ShopProduct>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        return await _http.GetFromJsonAsync<IReadOnlyList<ShopProduct>>("api/products", cancellationToken)
               ?? Array.Empty<ShopProduct>();
    }

    public async Task<ShopProduct?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _http.GetFromJsonAsync<ShopProduct>($"api/products/{id}", cancellationToken);
    }

    public Task AddProductAsync(ShopProduct product, CancellationToken cancellationToken = default)
    {
        // No-op in WASM client; server API should handle persistence.
        return Task.CompletedTask;
    }

    public Task UpdateProductAsync(ShopProduct product, CancellationToken cancellationToken = default)
    {
        // No-op in WASM client
        return Task.CompletedTask;
    }

    public Task DeleteProductAsync(int id, CancellationToken cancellationToken = default)
    {
        // No-op in WASM client
        return Task.CompletedTask;
    }
}
