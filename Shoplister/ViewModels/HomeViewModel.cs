using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoplister.Stores;
using Shoplister.Views;
using System.Collections.ObjectModel;

namespace Shoplister.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly ItemStore _itemStore;

    [ObservableProperty]
    private ObservableCollection<ItemViewModel> _items = new ();

    public HomeViewModel(ItemStore itemStore)
    {
        _itemStore = itemStore;
    }

    [RelayCommand]
    public async Task LoadItems()
    {
        var items = await _itemStore.GetItems();

        Items = new (items
            .Select(m => new ItemViewModel(m))
            .OrderBy(m => m.Checked)
            .ToList());
    }

    [RelayCommand]
    public async Task AddItems()
    {
        await Shell.Current.GoToAsync(nameof(CatalogPage));
    }

    [RelayCommand]
    public async Task ClearItems()
    {
        Items.Clear();

        await _itemStore.DeleteItems();
    }

    [RelayCommand]
    public async Task CheckItem(ItemViewModel item)
    {
        item.Checked = !item.Checked;

        var model = await _itemStore.GetItem(item.Id);

        model!.Checked = item.Checked;

        await _itemStore.UpdateItem(model);

        if (item.Checked)
            Items.Move(Items.IndexOf(item), Items.Count - 1);
    }

    [RelayCommand]
    public async Task DeleteItem(ItemViewModel item)
    {
        Items.Remove(item);

        var model = await _itemStore.GetItem(item.Id);

        await _itemStore.DeleteItem(model!);
    }
}