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
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace WpfCustomWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Module> Modules { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            
            LoadData();
        }

        private void LoadData()
        {
            Modules = new();
            for (int i = 1; i < 6; ++i)
            {
                Modules.Add(new() { Name = "Item " + i.ToString(), Subscibers = new Random().Next(0, 99) });
            }

            // list.ItemsSource = Modules;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void CtrlPanalBar_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                if (WindowState is WindowState.Maximized)
                    WindowState = WindowState.Normal;
                else
                    WindowState = WindowState.Maximized;
            }

            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(this);
            SendMessage(windowInteropHelper.Handle, 161, 2, 0);
        }

        private void CtrlPanalBar_OnMouseEnter(object sender, MouseEventArgs e)
        {
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
    }

    public class Module
    {
        public string Name { get; set; }
        public int Subscibers { get; set; }
    }
}