using Avalonia.Styling;
using Prism.Commands;
using SchoolManagement.Auth.Views;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System;
using System.Windows.Input;

namespace SchoolManagement.Shell.ViewModels
{
    public class CommonMenuViewModel : BaseRegionViewModel
    {
        private readonly IAppManager _appManager;
        private Language currentLanguage;
        private bool isDesktopPlatform = true;

        public CommonMenuViewModel()
        {
            User = RootContext.CurrentUser;
            _appManager = Ioc.Resolve<IAppManager>();
            CurrentLanguage = BootSetting.CurrentLanguage;
            ValidateFlatform();
        }

        public ICommand ChangeLanguageCommand { get; set; }
        public ICommand ChangeThemeCommand { get; set; }

        public Language CurrentLanguage
        {
            get => currentLanguage; set
            {
                SetProperty(ref currentLanguage, value);
            }
        }

        public bool IsDesktopPlatform { get => isDesktopPlatform; set => SetProperty(ref isDesktopPlatform, value); }
        public ICommand LogoutCommand { get; set; }
        public ICommand RequestRefreshPageCommand { get; set; }
        public ICommand SearchTextCommand { get; set; }
        public ICommand SettingAccountCommand { get; set; }
        public override string Title => Util.GetResourseString("CommonSettings_Label");
        public override User User { get; protected set; }

        protected override void RegisterCommand()
        {
            SearchTextCommand = new DelegateCommand<object>(OnSearch);
            ChangeThemeCommand = new DelegateCommand<object>(OnChangeTheme);
            ChangeLanguageCommand = new DelegateCommand(OnChangeLang);
            LogoutCommand = new DelegateCommand(OnLogout);
            RequestRefreshPageCommand = new DelegateCommand(OnRefresh);
            base.RegisterCommand();
        }

        protected override void OnLogginSuccess(bool isLoginSucess)
        {
            User = RootContext.CurrentUser;
        }

        private void OnChangeLang()
        {
            UpdateLanguage(CurrentLanguage);
        }

        private void OnChangeTheme(object obj)
        {
            if (BootSetting.CurrentTheme == ThemeVariant.Light)
            {
                ChangeTheme(ThemeVariant.Dark);
                return;
            }
            ChangeTheme(ThemeVariant.Light);
        }

        private void OnLogout()
        {
            RootContext.CurrentUser = new();
            SetMainView(new LoginView());
            SetMainPage(null);
            EventAggregator.GetEvent<LogoutSuccessEvent>().Publish();
        }

        private void OnRefresh()
        {
            var service = Ioc.Resolve<ISchoolManagementSevice>();
            if (service == null)
            {
                NotificationManager.ShowError(Util.GetResourseString("DatabaseFailed_Message"));
                return;
            }
            service.Refresh();
            EventAggregator.GetEvent<RequestRefreshPageEvent>().Publish();
        }

        private void OnSearch(object obj)
        {
        }

        private void UpdateLanguage(Language lang)
        {
            if (lang == null)
            {
                return;
            }
            var isChanged = LanguageHelper.ChangeLanguage(lang.LanguageType);
            if (!isChanged)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("ChangeLanguageError_Message"));
                return;
            }
            NotificationManager.ShowSuccess(Util.GetResourseString("ChangeLanguageSuccess_Message"));
            EventAggregator.GetEvent<ChangeLangEvent>().Publish();
            return;
        }

        private void ValidateFlatform()
        {
            if (OperatingSystem.IsAndroid() || OperatingSystem.IsIOS())
            {
                IsDesktopPlatform = false;
                return;
            }
            IsDesktopPlatform = true;
        }
    }
}