using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoplister.Models;
using Shoplister.Stores;
using System.Collections.ObjectModel;

namespace Shoplister.ViewModels;

public partial class CatalogViewModel : ObservableObject
{
    private readonly ItemStore _itemStore;

    [ObservableProperty]
    private ObservableCollection<Item> _items = new();

    public CatalogViewModel(ItemStore itemStore)
    {
        _itemStore = itemStore;
    }

    [RelayCommand]
    private async Task LoadItems()
    {
        var items = await _itemStore.GetItems();

        Items = new ObservableCollection<Item>(items);
    }
}
