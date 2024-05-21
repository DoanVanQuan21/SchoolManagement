using Avalonia.Styling;
using Prism.Commands;
using Prism.Events;
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
        private bool isDesktopPlatform = true;
        private Language currentLanguage;
        private readonly IAppManager _appManager;

        public CommonMenuViewModel()
        {
            User = RootContext.CurrentUser;
            _appManager = Ioc.Resolve<IAppManager>();
            ValidateFlatform();
        }

        public ICommand ChangeThemeCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand SearchTextCommand { get; set; }
        public ICommand SettingAccountCommand { get; set; }
        public ICommand RequestRefreshPageCommand { get; set; }
        public override string Title => Util.GetResourseString("CommonSettings_Label");
        public bool IsDesktopPlatform { get => isDesktopPlatform; set => SetProperty(ref isDesktopPlatform, value); }
        public override User User { get; protected set; }

        public Language CurrentLanguage
        {
            get => currentLanguage; set
            {
                SetProperty(ref currentLanguage, value);
                UpdateLanguage(CurrentLanguage);
            }
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
            _appManager.BootSetting.CurrentLanguage = lang;
            EventAggregator.GetEvent<ChangeLangEvent>().Publish();
            return;
        }

        protected override void RegisterCommand()
        {
            SearchTextCommand = new DelegateCommand<object>(OnSearch);
            ChangeThemeCommand = new DelegateCommand<object>(OnChangeTheme);
            LogoutCommand = new DelegateCommand(OnLogout);
            RequestRefreshPageCommand = new DelegateCommand(OnRefresh);
            base.RegisterCommand();
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

        private void OnSearch(object obj)
        {
            var t = "";
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