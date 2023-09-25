using NativeModernNav.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace NativeModernNav.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private CollectionViewSource? _menuItemsCollection;

    public ICollectionView SourceCollection => _menuItemsCollection.View;


    void LoadMenu()
    {
        ObservableCollection<MenuItem> menuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem { MenuName = "Dashboard", Icon = @"Resources/Assets/home_icon.jpg" },
                new MenuItem { MenuName = "Database", Icon = @"Resources/Assets/database_administrator_30px.png" },
                new MenuItem { MenuName = "Employees", Icon = @"Resources/Assets/management_30px.png" },
                new MenuItem { MenuName = "Visa", Icon = @"Assets/visa_30px.png" },
                new MenuItem { MenuName = "Passport Validity", Icon = @"Resources/Assets/customs_30px.png" },
                new MenuItem { MenuName = "Settings", Icon = @"Resources/Assets/Music_Icon.png" },
                new MenuItem { MenuName = "Movies", Icon = @"Assets/Movies_Icon.png" },
                new MenuItem { MenuName = "Trash", Icon = @"Assets/Trash_Icon.png" }
            };
    }
}
