using CommunityToolkit.Mvvm.ComponentModel;
using Shoplister.Models;

namespace Shoplister.ViewModels;

public partial class CatalogItemViewModel : ObservableObject
{
    private readonly Item _model;

    public string Name => _model.Name;

    public int Quantity => _model.Quantity;

    public DateTime CreationDate => _model.CreationDate;

    public CatalogItemViewModel(Item item)
    {
        _model = item;
    }
}
