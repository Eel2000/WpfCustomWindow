using System.Collections.Generic;
using MaterialDesignThemes.Wpf;
using WpfMaterialdesignEx.Models;

namespace WpfMaterialdesignEx.ViewModels;

public class MainViewModel
{
    private List<Module> _modules;

    public List<Module> Modules
    {
        get => _modules;
    }

    public MainViewModel() : base()
    {
        _modules = new()
        {
            new Module() { IconKind = PackIconKind.Android, Label = "Android" },
            new Module() { IconKind = PackIconKind.AppleIos, Label = "IOS" },
            new Module() { IconKind = PackIconKind.Desk, Label = "Windows" },
        };
    }
}