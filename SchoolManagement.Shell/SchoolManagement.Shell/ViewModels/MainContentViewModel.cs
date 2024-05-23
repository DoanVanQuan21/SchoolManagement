using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.Shell.Views.MobileViews;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SchoolManagement.Shell.ViewModels
{
    public class MainContentViewModel : BaseRegionViewModel
    {
        private bool isOpenPane = true;

        public MainContentViewModel() : base()
        {
            User = new();
            AppMenus = new();
            InitAppMenus();
        }

        public ObservableCollection<AppMenu> AppMenus { get; private set; }
        public ICommand ClickedSettingViewCommand { get; set; }
        public ICommand ClickNavigationCommand { get; set; }
        public ICommand ClickSelectionPageCommand { get; set; }

        public bool IsOpenPane
        { get => isOpenPane; set { SetProperty(ref isOpenPane, value); } }

        public override string Title => "Main Content";

        public override User User { get; protected set; }
        public AppMenu CurrentMenu { get; set; }

        protected override void OnLogginSuccess(bool isLoginSucess)
        {
            base.OnLogginSuccess(isLoginSucess);
            InitAppMenus();
        }

        protected override void RegisterCommand()
        {
            ClickNavigationCommand = new DelegateCommand(OnClickNavigation);
            ClickSelectionPageCommand = new DelegateCommand<object>(OnClickSelectionPage);
            ClickedSettingViewCommand = new DelegateCommand<object>(OnSettingView);
        }

        protected override void SubcribeEvent()
        {
            EventAggregator.GetEvent<RequestRefreshPageEvent>().Subscribe(OnRefresh);
            EventAggregator.GetEvent<ChangeLangEvent>().Subscribe(OnChangeLanguage);
        }

        private void OnChangeLanguage()
        {
            if (RootContext.MenuLabels.Count < 0)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("ChangeLanguageError_Message"));
                return;
            }
            foreach (var menu in AppMenus)
            {
                menu.Label = Util.GetResourseString(RootContext.MenuLabels[menu.Type]);
            }
            foreach (var menu in RootContext.DesktopAppMenus)
            {
                menu.Label = Util.GetResourseString(RootContext.MenuLabels[menu.Type]);
            }
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
            SetMainPage(AppMenus.First().View);
        }

        private void InitAppMenus()
        {
            AppMenus.Clear();
            AddMenus(RootContext.DesktopAppMenus);
        }

        private bool IsHavePermission(string role)
        {
            var roles = role.Split(',');
            var actualRole = roles.FirstOrDefault(r => r.ToLower() == RootContext.Role.ToString().ToLower());
            if (actualRole != null)
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
                NotificationManager.ShowError(Util.GetResourseString("DatabaseFailed_Message"));
                return;
            }
            SetMainPage(selectedPage.View);
        }

        private void OnRefresh()
        {
        }

        private void OnSettingView(object obj)
        {
            SetMainPage(new SettingView());
        }
    }
}