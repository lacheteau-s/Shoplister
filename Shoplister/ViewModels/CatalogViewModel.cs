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
    [NotifyPropertyChangedFor(nameof(HasSearchQuery))]
    private string _searchQuery = string.Empty;

    [ObservableProperty]
    private ObservableCollection<CatalogItemViewModel> _items = new();

    public bool HasSearchQuery => !string.IsNullOrWhiteSpace(SearchQuery);

    public CatalogViewModel(ItemStore itemStore)
    {
        _itemStore = itemStore;
    }

    [RelayCommand]
    private async Task LoadItems()
    {
        var items = await _itemStore.GetItems();

        Items = new (items
            .Select(x => new CatalogItemViewModel(x, _itemStore))
            .OrderByDescending(x => x.CreationDate)
            .ToList());
    }

    [RelayCommand]
    private async Task AddNewItem()
    {
        var item = new Item { Name = SearchQuery, Quantity = 1 };

        await _itemStore.AddItem(item);

        ClearSearchQuery();

        await LoadItems();
    }

    [RelayCommand]
    private void ClearSearchQuery()
    {
        SearchQuery = string.Empty;
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await Shell.Current.GoToAsync("..", true);
    }
}
