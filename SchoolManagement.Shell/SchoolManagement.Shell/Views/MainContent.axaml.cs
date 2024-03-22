using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views;

public partial class MainContent : UserControl
{
    public MainContent()
    {
        InitializeComponent();
        DataContext = Ioc.Resolve<MainContentViewModel>();
    }
}