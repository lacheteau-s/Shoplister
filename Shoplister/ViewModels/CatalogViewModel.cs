using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoplister.Stores;
using System.Collections.ObjectModel;

namespace Shoplister.ViewModels;

public partial class CatalogViewModel : ObservableObject
{
    private readonly ItemStore _itemStore;

    [ObservableProperty]
    private ObservableCollection<CatalogItemViewModel> _items = new();

    public CatalogViewModel(ItemStore itemStore)
    {
        _itemStore = itemStore;
    }

    [RelayCommand]
    private async Task LoadItems()
    {
        var items = await _itemStore.GetItems();

        Items = new (items
            .Select(x => new CatalogItemViewModel(x))
            .OrderBy(x => x.Name)
            .ToList());
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await Shell.Current.GoToAsync("..", true);
    }
}
