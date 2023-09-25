using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NativeModernNav.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace NativeModernNav.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private CollectionViewSource? _menuItemsCollection;

    public ICollectionView SourceCollection => _menuItemsCollection.View;

    [ObservableProperty] BaseViewModel _selectedViewModel;
    [ObservableProperty] ObservableCollection<MenuItem> _menuItems;

    public MainViewModel()
    {
        LoadMenu();

        _menuItemsCollection = new() { Source = MenuItems };

        SelectedViewModel = this;
    }


    void LoadMenu()
    {
        MenuItems = new ObservableCollection<MenuItem>
        {
            new MenuItem { MenuName = "Dashboard", Icon = @"/Resources/Assets/home_icon.jpg" },
            new MenuItem { MenuName = "Database", Icon = @"/Resources/Assets/database_administrator_30px.png" },
            new MenuItem { MenuName = "Employees", Icon = @"/Resources/Assets/management_30px.png" },
            new MenuItem { MenuName = "Visa", Icon = @"/Resources/Assets/visa_30px.png" },
            new MenuItem { MenuName = "Passport Validity", Icon = @"/Resources/Assets/customs_30px.png" },
            new MenuItem { MenuName = "Settings", Icon = @"/Resources/Assets/setting.png" }
        };
    }

    [RelayCommand]
    void Navigate(string viewModel)
    {
        try
        {
            var switcher = viewModel switch
            {
                "Dashboard" => SelectedViewModel = this,
                "Database" => SelectedViewModel = this,
                "Employees" => SelectedViewModel = this,
                "Visa" => SelectedViewModel = this,
                "Passport Validity" => this,
                "Settings" => this,
                _ => SelectedViewModel = this
            };
        }
        catch (System.Exception e)
        {

        }
    }
}
