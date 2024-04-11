using Prism.Commands;
using SchoolManagement.Auth.Views;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using System;
using System.Windows.Input;
using Avalonia.Styling;
using Avalonia;

namespace SchoolManagement.Shell.ViewModels
{
    public class CommonMenuViewModel : BaseRegionViewModel
    {
        public override string Title => throw new System.NotImplementedException();
        public ICommand SearchTextCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand SettingAccountCommand { get; set; }
        public ICommand ChangeThemeCommand { get; set; }

        public CommonMenuViewModel()
        {
        }

        protected override void RegisterCommand()
        {
            SearchTextCommand = new DelegateCommand<object>(OnSearch);
            ChangeThemeCommand = new DelegateCommand<object>(OnChangeTheme);
            LogoutCommand = new DelegateCommand(OnLogout);
            base.RegisterCommand();
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
        }

        private void OnSearch(object obj)
        {
            var t = "";
        }
    }
}