using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.SettingAccount.ViewModels;

namespace SchoolManagement.SettingAccount.Views
{
    public partial class SettingAccountView : UserControl
    {
        public SettingAccountView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<SettingAccountViewModel>();
        }
    }
}