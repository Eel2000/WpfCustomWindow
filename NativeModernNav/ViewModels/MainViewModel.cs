using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NativeModernNav.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
        Title = "Resource Not Found";

        LoadMenu();
    }


    void LoadMenu()
    {
        MenuItems = new ObservableCollection<MenuItem>
        {
            new MenuItem { MenuName = "Dashboard", Icon = @"/Resources/Assets/home_icon.jpg" , Active = true},
            new MenuItem { MenuName = "Database", Icon = @"/Resources/Assets/database_administrator_30px.png" },
            new MenuItem { MenuName = "Employees", Icon = @"/Resources/Assets/management_30px.png" },
            new MenuItem { MenuName = "Visa", Icon = @"/Resources/Assets/visa_30px.png" },
            new MenuItem { MenuName = "Passport Validity", Icon = @"/Resources/Assets/customs_30px.png" },
            new MenuItem { MenuName = "Settings", Icon = @"/Resources/Assets/setting.png" }
        };

        SelectedViewModel = new DashboardViewModel();

        _menuItemsCollection = new() { Source = MenuItems };
    }

    [RelayCommand]
    void Navigate(string viewModel)
    {
        try
        {

            //foreach (var menu in MenuItems)
            //    menu.Active = false;

            //var toDeactivate = MenuItems.FirstOrDefault(x => x.MenuName == viewModel);
            //toDeactivate.Active = true;

            var switcher = viewModel switch
            {
                "Dashboard" => SelectedViewModel = new DashboardViewModel(),
                "Database" => SelectedViewModel = new DatabaseViewModel(),
                "Employees" => SelectedViewModel = this,
                "Visa" => SelectedViewModel =this,
                "Passport Validity" => this,
                "Settings" => this,
                _ => SelectedViewModel = new DashboardViewModel()
            };
        }
        catch (System.Exception e)
        {

        }
    }
}
