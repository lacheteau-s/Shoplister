using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoplister.Models;
using Shoplister.Stores;
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
        var num = Items.Any() ? Items.Max(i => i.Id) : 0;

        var item = new Item
        {
            Name = $"Item {num + 1}",
            Quantity = 1,
            Checked = false
        };

        Items.Add(new ItemViewModel(item));

        await _itemStore.AddItem(item);
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

        model.Checked = item.Checked;

        await _itemStore.UpdateItem(model);

        if (item.Checked)
            Items.Move(Items.IndexOf(item), Items.Count - 1);
    }

    [RelayCommand]
    public async Task DeleteItem(ItemViewModel item)
    {
        Items.Remove(item);

        var model = await _itemStore.GetItem(item.Id);

        await _itemStore.DeleteItem(model);
    }
}