using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views.DesktopViews;

public partial class DesktopHeaderView : UserControl
{
    public DesktopHeaderView()
    {
        InitializeComponent();
        DataContext = Ioc.Resolve<CommonMenuViewModel>();
    }
}