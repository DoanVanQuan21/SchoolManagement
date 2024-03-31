using Avalonia.Controls;
using Avalonia.Threading;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagement.Shell.Views.SplashScreen;

public partial class SplashScreen : UserControl
{
    public SplashScreen()
    {
        InitializeComponent();
        DataContext = Ioc.Resolve<SplashScreenViewModel>();
    }
}