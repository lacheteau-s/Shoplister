using Shoplister.Views;
using Shoplister.ViewModels;

namespace Shoplister.Configuration;

internal static class Startup
{
    public static MauiAppBuilder ConfigureMvvm(this MauiAppBuilder builder)
    {
        var services = builder.Services;

        services.AddSingleton<HomePage>();
        services.AddSingleton<HomeViewModel>();

        return builder;
    }
}
