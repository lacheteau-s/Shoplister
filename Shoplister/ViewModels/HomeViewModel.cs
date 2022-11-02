﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoplister.Stores;
using System.Collections.ObjectModel;

namespace Shoplister.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly ItemStore _itemStore;

    [ObservableProperty]
    private ObservableCollection<HomeItemViewModel> _items = new ();

    public HomeViewModel(ItemStore itemStore)
    {
        _itemStore = itemStore;
    }

    [RelayCommand]
    public async Task LoadItems()
    {
        var items = await _itemStore.GetItems();

        Items = new (items
            .Select(m => new HomeItemViewModel(m))
            .OrderBy(m => m.Checked)
            .ToList());
    }

    [RelayCommand]
    public async Task AddItems()
    {
        await Shell.Current.GoToAsync(Constants.Routing.Catalog);
    }

    [RelayCommand]
    public async Task ClearItems()
    {
        Items.Clear();

        await _itemStore.DeleteItems();
    }

    [RelayCommand]
    public async Task CheckItem(HomeItemViewModel item)
    {
        item.Checked = !item.Checked;

        var model = await _itemStore.GetItem(item.Id);

        model!.Checked = item.Checked;

        await _itemStore.UpdateItem(model);

        if (item.Checked)
            Items.Move(Items.IndexOf(item), Items.Count - 1);
    }

    [RelayCommand]
    public async Task DeleteItem(HomeItemViewModel item)
    {
        Items.Remove(item);

        var model = await _itemStore.GetItem(item.Id);

        await _itemStore.DeleteItem(model!);
    }
}