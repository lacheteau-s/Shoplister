using Shoplister.Views;
using Shoplister.ViewModels;
using Shoplister.Stores;

namespace Shoplister.Configuration;

internal static class Startup
{
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
        services.AddSingleton<ItemStore>();
    }
}
