using SchoolManagement.Auth;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.Views;

namespace SchoolManagement.Shell.ViewModels
{
    public class MainViewModel : BaseRegionViewModel
    {
        public override string Title => "Main View";

        public MainViewModel()
        {
            //InitView();
            AppRegion.MainView = new MainContent();
        }

        protected override void InitView()
        {
            if (IsLogin)
            {
                AppRegion.MainView = new MainContent();
                return;
            }
            AppRegion.MainView = new LoginView();
        }
    }
}