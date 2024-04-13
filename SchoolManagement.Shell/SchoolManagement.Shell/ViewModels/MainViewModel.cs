﻿using Avalonia.Controls.Notifications;
using SchoolManagement.Auth;
using SchoolManagement.Auth.Views;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Managers;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.Shell.Views;
using SchoolManagement.Shell.Views.DesktopViews;
using SchoolManagement.Shell.Views.SplashScreen;
using System;
using System.Threading.Tasks;

namespace SchoolManagement.Shell.ViewModels
{
    public class MainViewModel : BaseRegionViewModel
    {
        public MainViewModel()
        {
            User = new();
            InitViewFollowPlatformAsync().GetAwaiter();
        }

        public override string Title => "Main View";

        public override User User { get; protected set; }

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

        protected override void OnLogginSuccess(bool isLoginSucess)
        {
            if (!isLoginSucess)
            {
                NotificationManager.ShowWarning("Tên đăng nhập hoặc mật khẩu không đúng!");
                return;
            }
            SetStateLogin(true);
            NotificationManager.ShowSuccess("Đăng nhập thành công!");
            SetMainViewFromPlatform();
        }

        protected override void SubcribeEvent()
        {
            base.SubcribeEvent();
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

        private void SetMainViewFromPlatform()
        {
            if (OperatingSystem.IsAndroid() || OperatingSystem.IsIOS())
            {
                SetMainView(new DesktopContentView());

                return;
            }

            SetMainView(new DesktopContentView());
        }
    }
}