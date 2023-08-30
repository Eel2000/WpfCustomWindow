using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using WpfMahAppsMetro.Views;

namespace WpfMahAppsMetro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly Navigation.NavigationServiceEx _navigationServiceEx;

        public MainWindow()
        {
            InitializeComponent();

            _navigationServiceEx = new Navigation.NavigationServiceEx();
            _navigationServiceEx.Navigated += NavigationServiceEx_OnNavigated;

            HamburgerMenuControl.Content = _navigationServiceEx.Frame;

            Loaded += (sender, args) =>
                _navigationServiceEx.Navigate(new Uri($"Views/{nameof(Dashboard)}.xaml", UriKind.RelativeOrAbsolute));
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs args)
        {
            if (args.InvokedItem is Customs.MenuItem menuItem && menuItem.IsNavigation)
                _navigationServiceEx.Navigate(menuItem.NavigationDestination);
        }


        private void NavigationServiceEx_OnNavigated(object sender, NavigationEventArgs e)
        {
            // select the menu item
            this.HamburgerMenuControl.SetCurrentValue(HamburgerMenu.SelectedItemProperty,
                this.HamburgerMenuControl.Items
                    .OfType<Customs.MenuItem>()
                    .FirstOrDefault(x => x.NavigationDestination == e.Uri));
            this.HamburgerMenuControl.SetCurrentValue(HamburgerMenu.SelectedOptionsItemProperty,
                this.HamburgerMenuControl
                    .OptionsItems
                    .OfType<Customs.MenuItem>()
                    .FirstOrDefault(x => x.NavigationDestination == e.Uri));


            // update back button
            // this.GoBackButton.SetCurrentValue(VisibilityProperty, this.navigationServiceEx.CanGoBack ? Visibility.Visible : Visibility.Collapsed);
        }

        private void GoBack_OnClick(object sender, RoutedEventArgs e)
        {
            _navigationServiceEx.GoBack();
        }
    }
}