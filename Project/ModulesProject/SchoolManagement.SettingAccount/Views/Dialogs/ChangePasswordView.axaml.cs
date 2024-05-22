using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.SettingAccount.ViewModels;

namespace SchoolManagement.SettingAccount.Views.Dialogs
{
    public partial class ChangePasswordView : UserControl
    {
        public ChangePasswordViewModel ViewModel { get; set; }

        public ChangePasswordView()
        {
            InitializeComponent();
            ViewModel = Ioc.Resolve<ChangePasswordViewModel>();
            DataContext = ViewModel;
        }

        public void SetChangePasswordEvent(Action<User> action)
        {
            ViewModel.ChangePassword = action;
        }
    }
}