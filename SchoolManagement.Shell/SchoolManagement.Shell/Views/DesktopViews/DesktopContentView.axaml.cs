using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views.DesktopViews
{
    public partial class DesktopContentView : UserControl
    {
        public DesktopContentView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<MainContentViewModel>();
        }
    }
}