using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoplister.Models;
using System.Collections.ObjectModel;

namespace Shoplister.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly List<Item> _itemStore;

    [ObservableProperty]
    private ObservableCollection<ItemViewModel> _items = new ();

    public HomeViewModel()
    {
        _itemStore = new()
        {
            new () { Id = 1, Name = "Item 1", Quantity = 1, Checked = false },
            new () { Id = 2, Name = "Item 2", Quantity = 1, Checked = false },
            new () { Id = 3, Name = "Item 3", Quantity = 1, Checked = false }
        };
    }

    [RelayCommand]
    public void LoadItems()
    {
        var items = _itemStore.Select(m => new ItemViewModel(m)).ToList();

        Items = new (items);
    }

    [RelayCommand]
    public void AddItems()
    {
        var num = _itemStore.Any() ? _itemStore.Max(i => i.Id) : 0;

        var item = new Item
        {
            Id = num + 1,
            Name = $"Item {num + 1}",
            Quantity = 1,
            Checked = false
        };

        Items.Add(new ItemViewModel(item));

        _itemStore.Add(item);
    }

    [RelayCommand]
    public void ClearItems()
    {
        Items.Clear();

        _itemStore.Clear();
    }

    [RelayCommand]
    public void CheckItem(ItemViewModel item)
    {
        item.Checked = !item.Checked;

        _itemStore.Find(x => x.Id == item.Id).Checked = item.Checked;

        if (item.Checked)
            Items.Move(Items.IndexOf(item), Items.Count - 1);
    }

    [RelayCommand]
    public void DeleteItem(ItemViewModel item)
    {
        Items.Remove(item);

        var model = _itemStore.Find(x => x.Id == item.Id);

        _itemStore.Remove(model);
    }
}