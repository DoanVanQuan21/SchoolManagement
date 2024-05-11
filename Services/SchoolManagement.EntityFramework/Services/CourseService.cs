using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class CourseService : ICourseService
    {
        private readonly IClassService _classService;
        private ISchoolManagementSevice _schoolManagementSevice;
        private readonly ISubjectService _subjectService;

        public CourseService() : base()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
            _classService = Ioc.Resolve<IClassService>();
            _subjectService = Ioc.Resolve<ISubjectService>();
        }

        public Task<ObservableCollection<Course>> GetCourses(int teacherID, int subjectID, int classID, int year)
        {
            return Task.Factory.StartNew(() =>
            {
                var courses = new ObservableCollection<Course>();
                var cs = _schoolManagementSevice.CourseRepository.Where(c => c.TeacherId == teacherID
                                                                                    && c.SubjectId == subjectID
                                                                                    && c.ClassId == classID
                                                                                    && c.StartDate.Year == year);
                if (cs?.Any() == false)
                {
                    return courses;
                }
                courses.AddRange(cs);
                return courses;
            });
        }

        public async Task<Course?> GetCourseByID(int courseID)
        {
            var course = await _schoolManagementSevice.CourseRepository.GetCourseById(courseID);
            if (course == null)
            {
                return course;
            }
            course.Subject = await _subjectService.GetSubject(course.SubjectId);
            course.Class = await _classService.GetClassByID(course.ClassId);
            return course;
        }

        public async Task<ObservableCollection<Course>> GetCourseOfTeacherByYear(int teacherID, int year, string semester)
        {
            var courses = await _schoolManagementSevice.CourseRepository.GetCourseOfTeacherByYear(teacherID, year, semester);
            foreach (var course in courses)
            {
                course.Class = await _classService.GetClassByID(course.ClassId);
            }
            return courses;
        }

        public Task<Course?> GetCourse(int teacherID, int classID, int year, string semester)
        {
            return Task.Factory.StartNew(() =>
            {
                var course = _schoolManagementSevice.CourseRepository.FirstOrDefault(c => c.TeacherId == teacherID
                && c.ClassId == classID
                && c.StartDate.Year == year && c.Semester == semester);
                return course;
            });
        }

        public Task<ObservableCollection<Course>> GetCourses(int year, string semester, int classId)
        {
            return Task.Factory.StartNew(() =>
            {
                var courses = new ObservableCollection<Course>();
                var actualCourses = _schoolManagementSevice.CourseRepository.Where(c => c.ClassId == classId && c.StartDate.Year == year && c.Semester == semester);
                if (actualCourses?.Any() == false)
                {
                    return courses;
                }
                courses.AddRange(actualCourses);
                return courses;
            });
        }

        public Task<List<int>> GetSubjectIDs(int classID,int year, string semester)
        {
            return Task.Factory.StartNew(() =>
            {
                var ids= new List<int>();
                var courses = _schoolManagementSevice.CourseRepository.Where(c => c.ClassId == classID && c.StartDate.Year == year && c.Semester == semester);
                if( courses?.Any() == false)
                {
                    return ids;
                }
                var actualIds = courses.Select(c => c.SubjectId);
                ids.AddRange(actualIds);
                return ids;
            });
        }

        public Task<bool> AddCourse(Course course)
        {
            return Task.Factory.StartNew(() =>
            {
                if(course == null)
                {
                    return false;
                }
                _schoolManagementSevice.CourseRepository.Add(course);
                return true;
            });
        }
    }
}