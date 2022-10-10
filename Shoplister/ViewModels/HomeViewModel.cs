using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoplister.Models;
using System.Collections.ObjectModel;

namespace Shoplister.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ItemViewModel> _items = new ();

    [RelayCommand]
    public void AddItems()
    {
        var num = Items.Any() ? Items.Max(i => int.Parse(i.Name.Split(" ").Last())) : 0;

        var item = new Item
        {
            Name = $"Item {num + 1}",
            Quantity = 1
        };

        Items.Add(new ItemViewModel(item));
    }

    [RelayCommand]
    public void ClearItems()
    {
        Items.Clear();
    }
}