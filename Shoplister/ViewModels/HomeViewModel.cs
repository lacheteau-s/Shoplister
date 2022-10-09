using CommunityToolkit.Mvvm.ComponentModel;
using Shoplister.Models;
using System.Collections.ObjectModel;

namespace Shoplister.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Item> _items;

    public HomeViewModel()
    {
        Items = new ()
        {
            new () { Name = "Item 1", Quantity = 1 },
            new () { Name = "Item 2", Quantity = 1 },
            new () { Name = "Item 3", Quantity = 1 }
        };
    }
}