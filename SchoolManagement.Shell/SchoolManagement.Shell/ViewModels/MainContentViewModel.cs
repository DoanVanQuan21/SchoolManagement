using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.Shell.ViewModels
{
    public class MainContentViewModel : BaseRegionViewModel
    {
        private bool isOpenPane = true;

        public override string Title => "Main Content";

        public MainContentViewModel()
        {
            RootContext.AppMenus.Add(new AppMenu() { Label = "Trang chủ" });
        }

        public bool IsOpenPane
        { get => isOpenPane; set { SetProperty(ref isOpenPane, value); } }

        public ICommand ClickNavigationCommand { get; set; }
        public ObservableCollection<AppMenu> AppMenus => RootContext.AppMenus;

        protected override void RegisterCommand()
        {
            ClickNavigationCommand = new DelegateCommand(OnClickNavigation);
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

        protected override void RegisterEvent()
        {
        }
    }
}