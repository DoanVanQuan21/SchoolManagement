using Avalonia.Controls;
using SchoolManagement.AccountManagement.ViewModels;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.AccountManagement.Views.Dialogs
{
    public partial class AddUserView : UserControl
    {
        private AddAccountViewModel AccountViewModel;

        public AddUserView()
        {
            InitializeComponent();
            AccountViewModel = Ioc.Resolve<AddAccountViewModel>();
            DataContext = AccountViewModel;
        }

        public void SetAddAccountAction(Action<User> action)
        {
            AccountViewModel.AddUser = action;
        }
    }
}