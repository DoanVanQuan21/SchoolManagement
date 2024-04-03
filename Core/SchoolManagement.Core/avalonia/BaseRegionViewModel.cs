using Avalonia.Controls;
using Avalonia.Notification;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models;
using SchoolManagement.Core.Models.Common;

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
        { }

        protected virtual void SubcribeEvent()
        { }

        protected readonly IEventAggregator EventAggregator;
        public INotificationMessageManager NotificationMessageManager { get; private set; }
        protected IDialogService DialogService { get; private set; }

        public BaseRegionViewModel()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            NotificationMessageManager = Ioc.Resolve<INotificationMessageManager>();
            EventAggregator = Ioc.Resolve<IEventAggregator>();
            DialogService = Ioc.Resolve<IDialogService>();
            RegisterCommand();
            SubcribeEvent();
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
            if(mainView == null || mainView == default)
            {
                return;
            }
            SetMainView(mainView);
        }
        public void SetMainView(UserControl mainView)
        {
            if(AppRegion.MainView != null)
            {
                PushMainView(AppRegion.MainView.GetType());
            }
            AppRegion.MainView = mainView;
        }

        public void SetMainPage(UserControl mainPage)
        {
            AppRegion.MainPage = mainPage;
        }

        private void OnLogginSuccess(bool isLoginSucess)
        {
            if (!isLoginSucess)
            {
                return;
            }
            SetStateLogin(true);
        }

        private void SetStateLogin(bool isLogin)
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