using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class CourseRepository : GenerateRepository<Course>, ICourseRepository<Course>
    {
        private ObservableCollection<Course> _courses;

        public CourseRepository(SchoolManagementContext context) : base(context)
        {
            _courses = new();
        }

        public Task<ObservableCollection<Course>> GetCourseOfTeacherByYear(int teacherID, int year, string semester)
        {
            return Task.Factory.StartNew(() =>
            {
                _courses.Clear();

                var courses = Where(c => c.TeacherId == teacherID && c.StartDate.Year == year && c.Semester == semester);
                if (courses?.Any() == false)
                {
                    return _courses;
                }
                var t = _context.Courses.ToList();
                _courses.AddRange(courses);
                return _courses;
            });
        }

        public Task<Course?> GetCourseById(int courseID)
        {
            return Task.Factory.StartNew(() =>
            {
                return FirstOrDefault(c => c.CourseId == courseID);
            });
        }
    }
}