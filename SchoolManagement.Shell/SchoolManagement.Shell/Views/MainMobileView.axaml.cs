using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views
{
    public partial class MainMobileView : UserControl
    {
        public MainMobileView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<MainViewModel>();

        }
    }
}
