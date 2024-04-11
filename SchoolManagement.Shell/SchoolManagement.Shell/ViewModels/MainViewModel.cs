using Avalonia.Controls.Notifications;
using SchoolManagement.Auth;
using SchoolManagement.Auth.Views;
using SchoolManagement.Core.avalonia;
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
                await Task.Delay(100);
            }
        }

        protected override void SubcribeEvent()
        {
            base.SubcribeEvent();
        }

        protected override void OnLogginSuccess(bool isLoginSucess)
        {
            //WindowNotificationManager.Show(new Notification("Success", "Đăng nhập thành công"));
            //if (!isLoginSucess)
            //{
            //    NotificationManager.ShowWarn(NotificationMessageManager, "Tên đăng nhập hoặc mật khẩu không đúng!");
            //    return;
            //}
            //SetStateLogin(true);
            //NotificationManager.ShowSuccess(NotificationMessageManager, "Đăng nhập thành công!");
            //SetMainViewFromPlatform();
        }

        protected override async Task InitViewFollowPlatformAsync()
        {
            await InitSplashScreen();
            if (!IsLogin)
            {
                SetMainView(new LoginView());
                return;
            }

            SetMainViewFromPlatform();
        }

        private void SetMainViewFromPlatform()
        {
            if (OperatingSystem.IsAndroid() || OperatingSystem.IsIOS())
            {
                SetMainView(new MainMobileView());

                return;
            }

            SetMainView(new DesktopContentView());
        }
    }
}