using Microsoft.Extensions.Logging;
using ShopFrontend.Services;

namespace ShopFrontend;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
       


        builder.Services.AddMauiBlazorWebView();
		builder.Services.AddHttpClient<IShopCatalogService, ShopCatalogService>(client =>
		{
			client.BaseAddress = new Uri("https://api.example.test/");
		});


        builder.Services.AddScoped<IShopProductService, ShopProductService>();
        builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
        builder.Services.AddScoped<IShopCustomerService, ShopCustomerService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
		builder.Services.AddScoped<IShopCatalogService, ShopCatalogService>();





#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        return builder.Build();
	}
}
