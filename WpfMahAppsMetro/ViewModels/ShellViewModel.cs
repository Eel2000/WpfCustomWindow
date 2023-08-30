using System;
using System.Collections.ObjectModel;
using MahApps.Metro.IconPacks;
using WpfMahAppsMetro.Customs;
using WpfMahAppsMetro.Mvvm;
using WpfMahAppsMetro.Views;

namespace WpfMahAppsMetro.ViewModels;

public class ShellViewModel : BaseViewModel
{
    public ObservableCollection<MenuItem> Menu { get; } = new();

    public ObservableCollection<MenuItem> OptionsMenu { get; } = new();

    public ShellViewModel()
    {
        InitializeMenu();
    }

    void InitializeMenu()
    {
        Menu.Add(new MenuItem()
        {
            Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.DashcubeBrands },
            Label = "Home",
            NavigationType = typeof(Dashboard),
            NavigationDestination = new Uri("Views/" + nameof(Dashboard) + ".xaml", UriKind.RelativeOrAbsolute)
        });

        Menu.Add(new MenuItem()
        {
            Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.SalesforceBrands },
            Label = "Manage",
            ToolTip = "Manage",
            NavigationType = typeof(Manage),
            NavigationDestination = new Uri("Views/" + nameof(Manage) + ".xaml", UriKind.RelativeOrAbsolute)
        });

        Menu.Add(new MenuItem()
        {
            Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserCircleRegular },
            Label = "Profile",
            ToolTip = "Profile",
            NavigationType = typeof(Profile),
            NavigationDestination = new Uri("Views/" + nameof(Profile) + ".xaml", UriKind.RelativeOrAbsolute)
        });

        OptionsMenu.Add(new MenuItem()
        {
            Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.WrenchSolid },
            Label = "Settings",
            ToolTip = "Settings",
            NavigationType = typeof(Dashboard),
            NavigationDestination = new Uri("Views/" + nameof(Settings) + ".xaml", UriKind.RelativeOrAbsolute)
        });
    }
}