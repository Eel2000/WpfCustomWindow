using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfAdonisMatDisgnEx.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty] private string _title;
}