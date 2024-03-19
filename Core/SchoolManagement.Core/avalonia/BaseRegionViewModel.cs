using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models;
using SchoolManagement.Core.Models.Common;
using System.Windows.Input;

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
        public ICommand? LoginCommand { get; set; }
        public ICommand? KeyUpCommand { get; set; }

        public event Action<IDialogResult>? RequestClose;

        protected abstract void RegisterCommand();

        protected abstract void RegisterEvent();

        protected readonly IEventAggregator EventAggregator;
        protected readonly IWindowService WindowService;
        protected IDialogService DialogService { get; private set; }

        public BaseRegionViewModel()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            EventAggregator = Ioc.Resolve<IEventAggregator>();
            WindowService = Ioc.Resolve<IWindowService>();
            DialogService = Ioc.Resolve<IDialogService>();
            RegisterCommand();
            RegisterEvent();
        }

        protected void DefaultView()
        {
            AppRegion.RegionPage = null;
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
    }
}