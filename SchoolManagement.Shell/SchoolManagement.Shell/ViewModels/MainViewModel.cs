using Avalonia.Controls;
using Prism.Mvvm;
using SchoolManagement.Auth;

namespace SchoolManagement.Shell.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private UserControl view;

        public UserControl View { get => view; set { SetProperty(ref view, value); } }
        public MainViewModel()
        {
            View = new LoginView();
        }
    }
}
