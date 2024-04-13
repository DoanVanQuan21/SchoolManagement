using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.MainProject.ViewModels;

namespace SchoolManagement.MainProject.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<DashboardViewModel>();
        }
    }
}