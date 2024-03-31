using SchoolManagement.Auth;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Managers;
using SchoolManagement.Shell.Views;
using SchoolManagement.Shell.Views.DesktopViews;
using SchoolManagement.Shell.Views.SplashScreen;
using System;
using System.Threading.Tasks;

namespace SchoolManagement.Shell.ViewModels
{
    public class MainViewModel : BaseRegionViewModel
    {
        public override string Title => "Main View";

        public MainViewModel()
        {
            InitViewFollowPlatformAsync().GetAwaiter();
        }

        private async Task InitSplashScreen()
        {
            SetMainView(new SplashScreen());
            var dataContext = AppRegion.MainView.DataContext as SplashScreenViewModel;
            while (!dataContext.IsLoaded)
            {
                await Task.Delay(500);
            }
        }
        protected override void SubcribeEvent()
        {
            EventAggregator.GetEvent<LoginSuccessEvent>().Subscribe(OnLogin);
            base.SubcribeEvent();
        }

        private void OnLogin()
        {
            if (OperatingSystem.IsAndroid() || OperatingSystem.IsIOS())
            {
                SetMainView(new MainMobileView());
                NotificationManager.ShowSuccess(NotificationMessageManager, "Đăng nhập thành công");
                return;
            }
            SetMainView(new DesktopContentView());
            NotificationManager.ShowSuccess(NotificationMessageManager, "Đăng nhập thành công");
        }

        protected override async Task InitViewFollowPlatformAsync()
        {
            await InitSplashScreen();
            if (!IsLogin)
            {
                SetMainView(new LoginView());
                return;
            }

            if (OperatingSystem.IsAndroid() || OperatingSystem.IsIOS())
            {
                SetMainView(new MainMobileView());

                return;
            }
            SetMainView(new DesktopContentView());
        }
    }
}