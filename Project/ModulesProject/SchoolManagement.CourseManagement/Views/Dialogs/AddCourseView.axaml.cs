using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.CourseManagement.ViewModels;

namespace SchoolManagement.CourseManagement.Views.Dialogs
{
    public partial class AddCourseView : UserControl
    {
        public AddCourseViewModel ViewModel { get; set; }

        public AddCourseView()
        {
            InitializeComponent();
            ViewModel = Ioc.Resolve<AddCourseViewModel>();
            DataContext = ViewModel;
        }

        public void SetAddCourseEvent(Action<Course> action)
        {
            ViewModel.AddCourseAction = action;
        }
    }
}