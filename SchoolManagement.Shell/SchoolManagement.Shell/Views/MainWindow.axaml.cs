using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<MainViewModel>();
        }
    }
}