using System.Collections.Generic;
using MaterialDesignThemes.Wpf;
using WpfAdonisMatDisgnEx.Models;

namespace WpfAdonisMatDisgnEx.ViewModels;

public class MainViewModel
{
    private List<Module> _modules = new()
    {
        new Module() { IconKind = PackIconKind.Android, Label = "Android" },
        new Module() { IconKind = PackIconKind.AppleIos, Label = "IOS" },
        new Module() { IconKind = PackIconKind.Desk, Label = "Windows" },
    };

    public List<Module> Modules
    {
        get => _modules;
    }
}