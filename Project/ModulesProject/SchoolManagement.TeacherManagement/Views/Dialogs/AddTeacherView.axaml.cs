using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.TeacherManagement.ViewModels;

namespace SchoolManagement.TeacherManagement.Views.Dialogs
{
    public partial class AddTeacherView : UserControl
    {
        public AddTeacherViewModel ViewModel { get; set; }

        public AddTeacherView()
        {
            InitializeComponent();
            ViewModel = Ioc.Resolve<AddTeacherViewModel>();
            DataContext = ViewModel;
        }

        public void SetAddTeacherEvent(Action<Teacher, User, Department, Subject> action)
        {
            ViewModel.AddTeacherAction = action;
        }
    }
}