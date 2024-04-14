using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class CourseService : ICourseService
    {
        private readonly ISchoolManagementSevice _schoolManagementSevice;

        public CourseService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
        }

        public ObservableCollection<Course> GetCourseByTeacherID(int TeacherID)
        {
            return _schoolManagementSevice.CourseRepository.GetCouseByTeacherID(TeacherID);
        }
    }
}