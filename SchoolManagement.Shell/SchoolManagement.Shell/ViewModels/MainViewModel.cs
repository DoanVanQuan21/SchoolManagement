using SchoolManagement.Auth;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.Views;
using SchoolManagement.Shell.Views.DesktopViews;
using System;

namespace SchoolManagement.Shell.ViewModels
{
    public class MainViewModel : BaseRegionViewModel
    {
        public override string Title => "Main View";

        public MainViewModel()
        {
            InitViewFollowPlatform();
        }

        protected override void InitViewFollowPlatform()
        {
            if (!IsLogin)
            {
                AppRegion.MainView = new LoginView();
                return;
            }

            if (OperatingSystem.IsAndroid() || OperatingSystem.IsIOS())
            {
                AppRegion.MainView = new MainMobileView();
                return;
            }
            AppRegion.MainView = new DesktopContentView();
        }
    }
}