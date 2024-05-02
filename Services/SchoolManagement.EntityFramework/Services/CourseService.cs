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

        public List<int> GetClassIDs(int teacherID)
        {
            return _schoolManagementSevice.CourseRepository.GetClassIDs(teacherID);
        }

        public Task<List<int>> GetClassIDsAsync(int teacherID)
        {
            return Task.Factory.StartNew(() =>
            {
                return GetClassIDs(teacherID);
            });
        }

        public async Task<Course?> GetCourseByClassAndSubjectID(int classID, int subjectID,int year)
        {
            return await _schoolManagementSevice.CourseRepository.GetCouseByClassAndSubjectID(classID, subjectID,year);
        }

        public async Task<ObservableCollection<Course>> GetCourseByClassID(int classID)
        {
            return await _schoolManagementSevice.CourseRepository.GetCouseByClassID(classID);
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
    }
}