using Avalonia.Controls;
using ImTools;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.StudentManagement.ViewModels;

namespace SchoolManagement.StudentManagement.Views.Dialogs
{
    public partial class AddStudentView : UserControl
    {
        public AddStudentViewModel ViewModel { get; set; }

        public AddStudentView()
        {
            InitializeComponent();
            ViewModel = Ioc.Resolve<AddStudentViewModel>();
            DataContext = ViewModel;
        }

        public void SetAddStudentEvent(Action<Student, User> action)
        {
            ViewModel.AddStudentAction = action;
        }
    }
}