using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Styling;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Models;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using INotificationManager = SchoolManagement.Core.Contracts.INotificationManager;

namespace SchoolManagement.Core.avalonia
{
    public abstract class BaseRegionViewModel : BindableBase, INavigationAware, IConfirmNavigationRequest, IDialogAware
    {
        private readonly IAppManager _appManager;
        private bool isLogin = false;

        public abstract string Title { get; }

        public bool IsLogin
        { get => isLogin; set { SetProperty(ref isLogin, value); } }

        public BootSetting BootSetting { get => _appManager.BootSetting; }
        public AppRegion AppRegion { get => _appManager.AppRegion; }

        public event Action<IDialogResult>? RequestClose;

        protected virtual void RegisterCommand()
        {
            EventAggregator.GetEvent<LoginSuccessEvent>().Subscribe(OnLogginSuccess);
        }

        protected virtual void SubcribeEvent()
        { }

        protected readonly IEventAggregator EventAggregator;
        protected IDialogService DialogService { get; private set; }
        public User User => RootContext.CurrentUser;
        public INotificationManager NotificationManager { get; private set; }

        public BaseRegionViewModel()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            EventAggregator = Ioc.Resolve<IEventAggregator>();
            DialogService = Ioc.Resolve<IDialogService>();
            NotificationManager = Ioc.Resolve<INotificationManager>();
            RegisterCommand();
            SubcribeEvent();
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
                NotificationManager.ShowError("Có lỗi khi đổi màu giao diện", TimeSpan.FromSeconds(3));
            }
        }

        protected void DefaultView()
        {
            //TODO
        }

        public void PushMainView(Type mainView)
        {
            RootContext.PreviewMainViews.Push(mainView);
        }

        public UserControl PopMainView()
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

        public void PreviewMainView()
        {
            var mainView = PopMainView();
            if (mainView == null || mainView == default)
            {
                return;
            }
            SetMainView(mainView);
        }

        public void SetMainView(UserControl mainView)
        {
            if (AppRegion.MainView != null)
            {
                PushMainView(AppRegion.MainView.GetType());
            }
            AppRegion.MainView = mainView;
        }

        public void SetMainPage(UserControl mainPage)
        {
            AppRegion.MainPage = mainPage;
        }

        protected virtual void OnLogginSuccess(bool isLoginSucess)
        {
        }

        protected void SetStateLogin(bool isLogin)
        {
            IsLogin = isLogin;
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        protected virtual void CloseDialog(string parameter = "")
        {
            ButtonResult res = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                res = ButtonResult.OK;
                RaiseRequestClose(new DialogResult(res));
                return;
            }
            res = ButtonResult.Cancel;
            RaiseRequestClose(new DialogResult(res));
        }

        protected virtual Task InitViewFollowPlatformAsync()
        {
            return Task.CompletedTask;
        }
    }
}