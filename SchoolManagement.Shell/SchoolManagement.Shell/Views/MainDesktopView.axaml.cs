using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views
{
    public partial class MainDesktopView : Window
    {
        public MainDesktopView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<MainViewModel>();
        }
    }
}
