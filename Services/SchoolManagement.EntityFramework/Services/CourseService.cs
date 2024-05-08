using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class CourseService : BaseService, ICourseService
    {
        public CourseService() : base()
        {
        }

        public Task<List<int>> GetClassIDsByTeacherIDAndYear(int teacherID, int year)
        {
            return Task.Factory.StartNew(() =>
            {
                return GetClassIDs(teacherID, year);
            });
        }

        public async Task<Course?> GetCourseByClassAndSubjectID(int classID, int subjectID, int year)
        {
            return await _schoolManagementSevice.CourseRepository.GetCouseByClassAndSubjectID(classID, subjectID, year);
        }

        public async Task<ObservableCollection<Course>> GetCourseByClassID(int classID)
        {
            return await _schoolManagementSevice.CourseRepository.GetCouseByClassID(classID);
        }

        public Task<ObservableCollection<Course>> GetCourseByClassID(int classID, int year)
        {
            return _schoolManagementSevice.CourseRepository.GetCourseByClassID(classID, year);
        }

        public ObservableCollection<Course> GetCourseByTeacherID(int TeacherID)
        {
            return _schoolManagementSevice.CourseRepository.GetCouseByTeacherID(TeacherID);
        }

        public Task<ObservableCollection<Course>> GetCourseByTeacherIDAsync(int TeacherID)
        {
            return Task.Factory.StartNew(() =>
            {
                return GetCourseByTeacherID(TeacherID);
            });
        }

        private List<int> GetClassIDs(int teacherID, int year)
        {
            return _schoolManagementSevice.CourseRepository.GetClassIDs(teacherID, year);
        }
    }
}