using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShopFrontend;
using ShopFrontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Routes>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register lightweight in-browser implementations for shared service interfaces so
// the Blazor WebAssembly app can render shared components without server-side EF.
builder.Services.AddScoped<IShopProductService, ShopFrontend.Web.Services.WebShopProductService>();
builder.Services.AddScoped<IShoppingCartService, ShopFrontend.Web.Services.WebShoppingCartService>();
builder.Services.AddScoped<IShopOrderService, ShopFrontend.Web.Services.WebShopOrderService>();
builder.Services.AddScoped<IShopCustomerService, ShopFrontend.Web.Services.WebShopCustomerService>();

await builder.Build().RunAsync();
