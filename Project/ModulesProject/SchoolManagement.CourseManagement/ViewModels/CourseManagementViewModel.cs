using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.CourseManagement.ViewModels
{
    internal class CourseManagementViewModel : BaseRegionViewModel
    {
        private Course selectedCourse;

        public override string Title => "Quản lý khóa học";

        public override User User { get; protected set; }

        public CourseManagementViewModel()
        {
            User = RootContext.CurrentUser;
        }

        public ObservableCollection<Course> Coureses { get; set; }
        public Course SelectedCourse { get => selectedCourse; set => SetProperty(ref selectedCourse, value); }
    }
}