using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class CourseService : BaseService, ICourseService
    {
        public CourseService() : base()
        {
        }

        public List<int> GetClassIDs(int teacherID)
        {
            return _schoolManagementSevice.CourseRepository.GetClassIDs(teacherID);
        }

        public ObservableCollection<Course> GetCourseByTeacherID(int TeacherID)
        {
            return _schoolManagementSevice.CourseRepository.GetCouseByTeacherID(TeacherID);
        }
    }
}