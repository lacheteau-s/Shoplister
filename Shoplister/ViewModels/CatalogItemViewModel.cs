using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoplister.Models;
using Shoplister.Stores;

namespace Shoplister.ViewModels;

public partial class CatalogItemViewModel : ObservableObject
{
    private readonly ItemStore _itemStore;

    private readonly Item _model;

    [ObservableProperty]
    private int _quantity;
    
    public string Name => _model.Name;

    public DateTime CreationDate => _model.CreationDate;

    public CatalogItemViewModel(Item item, ItemStore itemStore)
    {
        _itemStore = itemStore;
        _model = item;

        Quantity = _model.Quantity;
    }

    [RelayCommand]
    private async Task IncrementQuantity()
    {
        _model.Quantity = ++Quantity;

        await _itemStore.UpdateItem(_model);
    }

    [RelayCommand]
    private async Task DecrementQuantity()
    {
        if (Quantity == 0) return;

        _model.Quantity = --Quantity;

        await _itemStore.UpdateItem(_model);
    }
}
