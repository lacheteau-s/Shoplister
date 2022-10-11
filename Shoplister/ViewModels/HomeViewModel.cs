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
    public void LoadItems()
    {
        var items = _itemStore.GetItems().Select(m => new ItemViewModel(m)).ToList();

        Items = new (items);
    }

    [RelayCommand]
    public void AddItems()
    {
        var num = Items.Any() ? Items.Max(i => i.Id) : 0;

        var item = new Item
        {
            Name = $"Item {num + 1}",
            Quantity = 1,
            Checked = false
        };

        Items.Add(new ItemViewModel(item));

        _itemStore.AddItem(item);
    }

    [RelayCommand]
    public void ClearItems()
    {
        Items.Clear();

        _itemStore.DeleteItems();
    }

    [RelayCommand]
    public void CheckItem(ItemViewModel item)
    {
        item.Checked = !item.Checked;

        var model = _itemStore.GetItem(item.Id);
        model.Checked = item.Checked;

        _itemStore.UpdateItem(model);

        if (item.Checked)
            Items.Move(Items.IndexOf(item), Items.Count - 1);
    }

    [RelayCommand]
    public void DeleteItem(ItemViewModel item)
    {
        Items.Remove(item);

        var model = _itemStore.GetItem(item.Id);

        _itemStore.DeleteItem(model);
    }
}