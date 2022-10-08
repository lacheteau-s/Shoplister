using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Shoplister.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CounterText))]
    private int _count = 0;

    public string CounterText => _count == 0
        ? "Click me"
        : $"Clicked {_count} time{(_count > 1 ? "s" : "")}";

    [RelayCommand]
    public void IncrementCounter()
    {
        Count++;

        SemanticScreenReader.Announce(CounterText);
    }
}