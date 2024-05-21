using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views.MobileViews
{
    public partial class SettingView : UserControl
    {
        private readonly INotificationManager _notificationManager;
        private readonly IAppManager _appManager;

        public SettingView()
        {
            InitializeComponent();
            _appManager = Ioc.Resolve<IAppManager>();
            _notificationManager = Ioc.Resolve<INotificationManager>();
            DataContext = Ioc.Resolve<CommonMenuViewModel>();
        }
    }
}