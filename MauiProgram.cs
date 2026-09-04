using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Essentials;
using System.IO;
using ShopFrontend.Models;
using ShopFrontend.Services;

namespace ShopFrontend;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
			// load configuration from appsettings.json (optional)
			builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

			// Register EF Core DbContextFactory using SQLite. Use a factory to create short-lived
			// DbContext instances per operation which is safer for MAUI/Blazor lifetimes.
			// Store DB in platform app data directory to avoid permission/OneDrive issues.
			var dbPath = Path.Combine(FileSystem.AppDataDirectory, "shop.db");
			builder.Services.AddDbContextFactory<AppDbContext>(options =>
				options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? $"Data Source={dbPath}"));
			builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
       


        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddScoped<IShopProductService, ShopProductService>();
        builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
        builder.Services.AddScoped<IShopCustomerService, ShopCustomerService>();
        builder.Services.AddScoped<IShopOrderService, ShopOrderService>();
        builder.Services.AddScoped<IShopCatalogService, ShopCatalogService>();
        builder.Services.AddHttpClient<IShopCatalogService, ShopCatalogService>(client =>
		{
			client.BaseAddress = new Uri("https://api.example.test/");
		});


      





#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        return builder.Build();
	}
}
