using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views.MobileViews
{
    public partial class SettingView : UserControl
    {
        public SettingView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<CommonMenuViewModel>();
        }
    }
}