﻿using CommunityToolkit.Mvvm.ComponentModel;
using Shoplister.Models;

namespace Shoplister.ViewModels;

public partial class ItemViewModel : ObservableObject
{
    private readonly Item _model;

    public string Name => _model.Name;

    public int Quantity => _model.Quantity;

    public ItemViewModel(Item model)
    {
        _model = model;
    }
}