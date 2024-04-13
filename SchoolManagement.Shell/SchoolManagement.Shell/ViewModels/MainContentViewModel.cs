using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.SettingAccount.Views;
using SchoolManagement.UI.Geometry;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.Shell.ViewModels
{
    public class MainContentViewModel : BaseRegionViewModel
    {
        private bool isOpenPane = true;

        public MainContentViewModel()
        {
            User = new();
        }

        public ObservableCollection<AppMenu> AppMenus => RootContext.AppMenus;
        public ICommand ClickNavigationCommand { get; set; }
        public ICommand ClickSelectionPageCommand { get; set; }

        public bool IsOpenPane
        { get => isOpenPane; set { SetProperty(ref isOpenPane, value); } }

        public override string Title => "Main Content";

        public override User User { get; protected set; }

        protected override void RegisterCommand()
        {
            ClickNavigationCommand = new DelegateCommand(OnClickNavigation);
            ClickSelectionPageCommand = new DelegateCommand<object>(OnClickSelectionPage);
        }

        protected override void SubcribeEvent()
        {
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