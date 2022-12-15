using Shoplister.ViewModels;

namespace Shoplister.Views;

public partial class CatalogPage : ContentPage
{
	public CatalogPage(CatalogViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}