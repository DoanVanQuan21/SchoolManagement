using Avalonia.Controls;
using SchoolManagement.ClassManagement.ViewModels;
using SchoolManagement.Core.avalonia;

namespace SchoolManagement.ClassManagement.Views
{
    public partial class ClassManagementView : UserControl
    {
        public ClassManagementView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<ClassManagementViewModel>();
        }
    }
}
