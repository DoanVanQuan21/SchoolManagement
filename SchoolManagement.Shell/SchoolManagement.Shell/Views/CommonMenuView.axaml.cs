using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views;

public partial class CommonMenuView : UserControl
{
    public CommonMenuView()
    {
        InitializeComponent();
        DataContext = Ioc.Resolve<CommonMenuViewModel>();
    }
}