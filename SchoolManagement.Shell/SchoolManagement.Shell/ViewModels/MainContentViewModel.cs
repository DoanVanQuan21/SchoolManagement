using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.UI.Geometry;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.Shell.ViewModels
{
    public class MainContentViewModel : BaseRegionViewModel
    {
        private bool isOpenPane = true;

        public MainContentViewModel()
        {
            RootContext.AppMenus.Add(new AppMenu() { Label = "Trang chủ", Geometry = GeometryString.HomeGeometry });
        }

        public ObservableCollection<AppMenu> AppMenus => RootContext.AppMenus;
        public ICommand ClickNavigationCommand { get; set; }

        public bool IsOpenPane
        { get => isOpenPane; set { SetProperty(ref isOpenPane, value); } }

        public override string Title => "Main Content";

        protected override void RegisterCommand()
        {
            ClickNavigationCommand = new DelegateCommand(OnClickNavigation);
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
    }
}