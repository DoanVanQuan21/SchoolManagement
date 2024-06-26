﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using Prism.Events;
using Prism.Mvvm;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Models;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;
using INotificationManager = SchoolManagement.Core.Contracts.INotificationManager;

namespace SchoolManagement.Core.avalonia
{
    public abstract class BaseRegionViewModel : BindableBase
    {
        protected const int DEFAULT_ROW = 20;
        protected readonly string _dialogIdentifier = "MainDialogHost";
        protected readonly IEventAggregator EventAggregator;
        protected int page = 1;
        private readonly IAppManager _appManager;
        private bool isLogin = false;
        private bool isMobilePlatform;

        public BaseRegionViewModel()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            EventAggregator = Ioc.Resolve<IEventAggregator>();
            NotificationManager = Ioc.Resolve<INotificationManager>();
            RegisterCommand();
            SubcribeEvent();
            AppRegion.Title = Title;
            CheckPlatform();
            CloseDialog();
        }

        public AppRegion AppRegion { get => _appManager.AppRegion; }
        public BootSetting BootSetting { get => _appManager.BootSetting; }

        public bool IsLogin
        { get => isLogin; set { SetProperty(ref isLogin, value); } }

        public bool IsMobilePlatform { get => isMobilePlatform; set => SetProperty(ref isMobilePlatform, value); }
        public INotificationManager NotificationManager { get; private set; }
        public abstract string Title { get; }
        public abstract User User { get; protected set; }
        public ObservableCollection<Language> Languages => RootContext.Languages;

        public void PreviewMainView()
        {
            var mainView = TryPopMainView();
            if (mainView == null || mainView == default)
            {
                return;
            }
            SetMainView(mainView);
        }

        public void PushMainView(Type mainView)
        {
            RootContext.PreviewMainViews.Push(mainView);
        }

        public void SetMainPage(UserControl mainPage)
        {
            AppRegion.MainPage = mainPage;
        }

        public void SetMainView(UserControl mainView)
        {
            if (AppRegion.MainView != null)
            {
                PushMainView(AppRegion.MainView.GetType());
            }
            AppRegion.MainView = mainView;
        }

        public UserControl TryPopMainView()
        {
            RootContext.PreviewMainViews.TryPop(out var mainView);
            try
            {
                return (UserControl)Activator.CreateInstance(mainView);
            }
            catch (Exception)
            {
                return default;
            }
        }

        protected void ChangeTheme(ThemeVariant theme)
        {
            try
            {
                BootSetting.CurrentTheme = theme;
                Application.Current.RequestedThemeVariant = theme;
            }
            catch (Exception)
            {
                NotificationManager.ShowError("Có lỗi khi đổi màu giao diện");
            }
        }

        protected void CloseDialog()
        {
            try
            {
                if (!DialogHostAvalonia.DialogHost.IsDialogOpen(_dialogIdentifier))
                {
                    return;
                }
                DialogHostAvalonia.DialogHost.Close(_dialogIdentifier);
            }
            catch (Exception)
            {
                return;
            }
        }

        protected void DefaultView()
        {
            //TODO
        }

        protected virtual Task InitViewFollowPlatformAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual void OnLogginSuccess(bool isLoginSucess)
        {
            SetRole();
        }

        protected virtual void RegisterCommand()
        {
            EventAggregator.GetEvent<LoginSuccessEvent>().Subscribe(OnLogginSuccess);
        }

        protected void SetStateLogin(bool isLogin)
        {
            IsLogin = isLogin;
        }

        protected virtual async Task ShowDialogHost(object content)
        {
            await DialogHostAvalonia.DialogHost.Show(content, _dialogIdentifier);
        }

        protected virtual void SubcribeEvent()
        { }

        protected void UpdateCurrentUser(User user)
        {
            RootContext.UpdateCurrentUser(user);
        }

        private void SetRole()
        {
            if (RootContext.CurrentUser.Role == "student")
            {
                RootContext.Role = Role.Student;
                return;
            }
            if (RootContext.CurrentUser.Role == "teacher")
            {
                RootContext.Role = Role.Teacher;
                return;
            }
            RootContext.Role = Role.Admin;
        }

        private void CheckPlatform()
        {
            if (OperatingSystem.IsAndroid() || OperatingSystem.IsIOS())
            {
                IsMobilePlatform = true;
                return;
            }
            IsMobilePlatform = false;
        }
    }
}