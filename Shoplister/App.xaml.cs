namespace Shoplister;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		// TODO: https://github.com/lacheteau-s/Shoplister/issues/1
		Application.Current!.UserAppTheme = AppTheme.Light;

		MainPage = new AppShell();
	}
}
