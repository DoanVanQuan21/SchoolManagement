using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Database.ViewModels;

namespace SchoolManagement.Database.Views
{
    public partial class RegisterDatabaseView : UserControl
    {
        public RegisterDatabaseView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<RegisterDatabaseViewModel>();
        }
    }
}
