using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class CourseRepository : GenerateRepository<Course>, ICourseRepository<Course>
    {
        private ObservableCollection<Course> _coursesOfTeacher;
        private ObservableCollection<Course> _coursesOfClass;

        public CourseRepository(SchoolManagementContext context) : base(context)
        {
            _coursesOfTeacher = new();
            _coursesOfClass = new();
        }

        public Task<ObservableCollection<Course>> GetCouseByClassID(int classID)
        {
            return Task.Factory.StartNew(() =>
            {
                var courses = Where(item => item.ClassId == classID);
                if (courses == null)
                {
                    return _coursesOfTeacher;
                }
                _coursesOfClass.Clear();
                _coursesOfClass.AddRange(courses);
                return _coursesOfClass;
            });
        }

        public ObservableCollection<Course> GetCouseByTeacherID(int teacherID)
        {
            var courses = Where(item => item.TeacherId == teacherID);
            if (courses == null)
            {
                return _coursesOfTeacher;
            }
            _coursesOfTeacher.Clear();
            _coursesOfTeacher.AddRange(courses);
            return _coursesOfTeacher;
        }

        public List<int> GetClassIDs(int teacherID)
        {
            return GetCouseByTeacherID(teacherID).Select(item => item.ClassId).ToList();
        }
    }
}