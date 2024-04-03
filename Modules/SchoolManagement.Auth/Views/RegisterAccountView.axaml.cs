using Avalonia.Controls;
using SchoolManagement.Auth.ViewModels;
using SchoolManagement.Core.avalonia;

namespace SchoolManagement.Auth.Views;

public partial class RegisterAccountView : UserControl
{
    public RegisterAccountView()
    {
        InitializeComponent();
        DataContext = Ioc.Resolve<RegisterAccountViewModel>();
    }
}