using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.Shell.Views.MobileViews;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SchoolManagement.Shell.ViewModels
{
    public class MainContentViewModel : BaseRegionViewModel
    {
        private bool isOpenPane = true;

        public MainContentViewModel():base()
        {
            User = new();
            AppMenus = new();
            InitAppMenus();
        }

        public ObservableCollection<AppMenu> AppMenus { get; private set; }
        public ICommand ClickNavigationCommand { get; set; }
        public ICommand ClickSelectionPageCommand { get; set; }
        public ICommand ClickedSettingViewCommand { get; set; }
        public bool IsOpenPane
        { get => isOpenPane; set { SetProperty(ref isOpenPane, value); } }

        public override string Title => "Main Content";

        public override User User { get; protected set; }
        protected override void RegisterCommand()
        {
            ClickNavigationCommand = new DelegateCommand(OnClickNavigation);
            ClickSelectionPageCommand = new DelegateCommand<object>(OnClickSelectionPage);
            ClickedSettingViewCommand = new DelegateCommand<object>(OnSettingView);
        }

        private void OnSettingView(object obj)
        {
            SetMainPage(new SettingView());
        }

        protected override void OnLogginSuccess(bool isLoginSucess)
        {
            base.OnLogginSuccess(isLoginSucess);
            InitAppMenus();
        }
        private void InitAppMenus()
        {
            AppMenus.Clear();
            //if(OperatingSystem.IsAndroid() ||  OperatingSystem.IsIOS()) {
            //    AddMenus(RootContext.MobileAppMenus);
            //    return;
            //}
            AddMenus(RootContext.DesktopAppMenus);
        }
        private void AddMenus(ObservableCollection<AppMenu> appMenus)
        {
            foreach (var menu in appMenus)
            {
                if (!IsHavePermission(menu.Roles))
                {
                    continue;
                }
                AppMenus.Add(menu);
            }
        }
        private bool IsHavePermission(string role)
        {
            var roles = role.Split(',');
            var actualRole = roles.FirstOrDefault(r => r.ToLower() == RootContext.Role.ToString().ToLower());
            if(actualRole != null)
            {
                return true;
            }
            return false;
        }
        private void OnClickNavigation()
        {
            if (IsOpenPane)
            {
                IsOpenPane = false;
                return;
            }
            IsOpenPane = true;
        }
        private void OnClickSelectionPage(object obj)
        {
            var selectedPage = obj as AppMenu;
            if (selectedPage == null)
            {
                NotificationManager.ShowError("Không tải được nội dung!");
                return;
            }
            SetMainPage(selectedPage.View);
        }
    }
}