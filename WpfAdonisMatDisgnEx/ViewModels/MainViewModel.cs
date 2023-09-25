using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using WpfAdonisMatDisgnEx.Models;

namespace WpfAdonisMatDisgnEx.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty] private BaseViewModel _currentViewModel;
    [ObservableProperty] private PackIconKind _icon;

    [ObservableProperty] private List<Module> _modules = new()
    {
        new Module() { IconKind = PackIconKind.Android, Label = "Android" },
        new Module() { IconKind = PackIconKind.AppleIos, Label = "IOS" },
        new Module() { IconKind = PackIconKind.Desk, Label = "Windows" },
    };


    public MainViewModel()
    {
        Title = "Menu side";
        CurrentViewModel = new HomeViewModel();
    }

    [RelayCommand]
    public void ShowHomeView()
    {
        CurrentViewModel = new HomeViewModel();
        Icon = PackIconKind.Home;
    }

    [RelayCommand]
    public void ShowSettingsView()
    {
        CurrentViewModel = new SettingsViewModel();
        Icon = PackIconKind.Settings;
    }
}