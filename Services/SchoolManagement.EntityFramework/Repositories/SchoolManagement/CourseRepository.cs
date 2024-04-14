using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class CourseRepository : GenerateRepository<Course>, ICourseRepository<Course>
    {
        private ObservableCollection<Course> _coursesOfTeacher;

        public CourseRepository(SchoolManagementContext context) : base(context)
        {
            _coursesOfTeacher = new();
        }

        public ObservableCollection<Course> GetCouseByClassID(int classID)
        {
            return new();
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
    }
}