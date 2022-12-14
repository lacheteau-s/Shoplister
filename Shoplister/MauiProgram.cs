using CommunityToolkit.Maui;
using Shoplister.Configuration;

namespace Shoplister;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureRouting()
			.ConfigureServices()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("mdi-fonts.ttf", "mdi-fonts");
			});

		return builder.Build();
	}
}
