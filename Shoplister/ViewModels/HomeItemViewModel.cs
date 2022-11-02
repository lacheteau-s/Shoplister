using CommunityToolkit.Mvvm.ComponentModel;
using Shoplister.Models;

namespace Shoplister.ViewModels;

public partial class HomeItemViewModel : ObservableObject
{
    private readonly Item _model;

    [ObservableProperty]
    private bool _checked;

    public int Id => _model.Id;

    public string Name => _model.Name;

    public int Quantity => _model.Quantity;

    public HomeItemViewModel(Item model)
    {
        _model = model;

        Checked = model.Checked;
    }
}
