using Avalonia.Controls;
using SchoolManagement.Auth.ViewModels;
using SchoolManagement.Core.avalonia;

namespace SchoolManagement.Auth.Views;

public partial class ForgotPasswordView : UserControl
{
    public ForgotPasswordView()
    {
        InitializeComponent();
        DataContext = Ioc.Resolve<ForgotPasswordViewModel>();
    }
}