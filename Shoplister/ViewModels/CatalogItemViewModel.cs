using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoplister.Models;

namespace Shoplister.ViewModels;

public partial class CatalogItemViewModel : ObservableObject
{
    private readonly Item _model;

    [ObservableProperty]
    private int _quantity;
    
    public string Name => _model.Name;

    public DateTime CreationDate => _model.CreationDate;

    public CatalogItemViewModel(Item item)
    {
        _model = item;

        Quantity = _model.Quantity;
    }

    [RelayCommand]
    private void IncrementQuantity()
    {
        Quantity++;
    }

    [RelayCommand]
    private void DecrementQuantity()
    {
        if (Quantity == 0) return;

        Quantity--;
    }
}
