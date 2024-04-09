using Avalonia.Controls;
using SchoolManagement.Auth.ViewModels;
using SchoolManagement.Core.avalonia;

namespace SchoolManagement.Auth;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
        var vm = Ioc.Resolve<LoginViewModel>();
        vm.Container = this;
        DataContext = vm;
    }
}