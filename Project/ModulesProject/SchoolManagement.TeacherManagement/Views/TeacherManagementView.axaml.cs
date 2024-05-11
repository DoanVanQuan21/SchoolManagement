using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.TeacherManagement.ViewModels;

namespace SchoolManagement.TeacherManagement.Views
{
    public partial class TeacherManagementView : UserControl
    {
        public TeacherManagementView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<TeacherManagementViewModel>();
        }
    }
}