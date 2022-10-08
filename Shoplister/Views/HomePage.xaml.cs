﻿using Shoplister.ViewModels;

﻿namespace Shoplister.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}