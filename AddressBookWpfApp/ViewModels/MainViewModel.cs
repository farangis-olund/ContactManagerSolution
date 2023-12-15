
using AddressBookLibrary.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AddressBookWpfApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private Contact _contact = new();
}
