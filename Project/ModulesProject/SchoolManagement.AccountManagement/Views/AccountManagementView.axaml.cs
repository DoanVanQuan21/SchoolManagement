using Avalonia.Controls;
using SchoolManagement.AccountManagement.ViewModels;
using SchoolManagement.Core.avalonia;

namespace SchoolManagement.AccountManagement.Views
{
    public partial class AccountManagementView : UserControl
    {
        public AccountManagementView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<AccountManagementViewModel>();
            Container.LoadingRow += Container_LoadingRow;
        }

        private void Container_LoadingRow(object? sender, DataGridRowEventArgs e)
        {
            e.Row.Header = $"{e.Row.GetIndex()+1}"; 
        }
    }
}
