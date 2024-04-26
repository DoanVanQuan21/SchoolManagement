using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using DocumentFormat.OpenXml.Spreadsheet;
using Prism.Events;
using Prism.Mvvm;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Models;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Diagnostics;
using INotificationManager = SchoolManagement.Core.Contracts.INotificationManager;

namespace SchoolManagement.Core.avalonia
{
    public abstract class BaseRegionViewModel : BindableBase
    {
        protected readonly string _dialogIdentifier = "MainDialogHost";
        protected readonly IEventAggregator EventAggregator;
        private readonly IAppManager _appManager;
        private bool isLogin = false;

        public BaseRegionViewModel()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            EventAggregator = Ioc.Resolve<IEventAggregator>();
            NotificationManager = Ioc.Resolve<INotificationManager>();
            RegisterCommand();
            SubcribeEvent();
        }

        public AppRegion AppRegion { get => _appManager.AppRegion; }
        public BootSetting BootSetting { get => _appManager.BootSetting; }

        public bool IsLogin
        { get => isLogin; set { SetProperty(ref isLogin, value); } }

        public INotificationManager NotificationManager { get; private set; }
        public abstract string Title { get; }
        public abstract User User { get; protected set; }

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
            Debug.WriteLine($">>>Change View: {nameof(AppRegion.MainView)} --- user: {RootContext.CurrentUser.ToString()}");
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
            NotificationManager.ShowWarning($"base: {isLoginSucess}");

        }

        protected virtual void RegisterCommand()
        {
            EventAggregator.GetEvent<LoginSuccessEvent>().Subscribe(OnLogginSuccess);
        }

        protected void SetStateLogin(bool isLogin)
        {
            IsLogin = isLogin;
        }

        protected virtual void SubcribeEvent()
        { }

        protected void UpdateCurrentUser(User user)
        {
            RootContext.UpdateCurrentUser(user);
        }

        protected virtual async Task ShowDialogHostAndClose(object content, bool isClose)
        {
            await DialogHostAvalonia.DialogHost.Show(content, _dialogIdentifier);
        }

        protected void CloseDialog()
        {
            DialogHostAvalonia.DialogHost.Close(_dialogIdentifier);
        }
    }
}