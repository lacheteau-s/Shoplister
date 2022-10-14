using Shoplister.Views;
using Shoplister.ViewModels;
using Shoplister.Stores;
using SQLite;

namespace Shoplister.Configuration;

internal static class Startup
{
    public static MauiAppBuilder ConfigureRouting(this MauiAppBuilder builder)
    {
        Routing.RegisterRoute(Constants.Routing.Home, typeof(HomePage));
        Routing.RegisterRoute(Constants.Routing.Catalog, typeof(CatalogPage));

        return builder;
    }

    public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
    {
        var services = builder.Services;

        RegisterMvvm(services);

        RegisterServices(services);

        return builder;
    }

    private static void RegisterMvvm(IServiceCollection services)
    {
        services.AddSingleton<HomePage>();
        services.AddSingleton<HomeViewModel>();
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<SQLiteAsyncConnection>(sp =>
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "shoplister.db3");
            var flags = SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite;

            return new SQLiteAsyncConnection(dbPath, flags);
        });

        services.AddSingleton<ItemStore>();
    }
}
