using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class StudentService : BaseService, IStudentService
    {
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;

        public StudentService() : base()
        {
            _userService = Ioc.Resolve<IUserService>();
            _courseService = Ioc.Resolve<ICourseService>();
        }

        public Task<bool> AddStudent(Student student)
        {
            return Task.Factory.StartNew(() =>
            {
                if (student == null)
                {
                    return false;
                }
                _schoolManagementSevice.StudentRepository.Add(student);
                return true;
            });
        }

        public Student? GetStudent(int studentID)
        {
            var student = _schoolManagementSevice.StudentRepository.GetStudent(studentID);
            if (student == null)
            {
                return student;
            }
            student.User = _userService.GetUser(student.UserId);
            return student;
        }

        public Student? GetStudent(string studentCode)
        {
            return _schoolManagementSevice.StudentRepository.GetStudent(studentCode);
        }

        public Task<Student?> GetStudentByStudentCodeAsync(string studentCode)
        {
            return Task.Factory.StartNew(
            () =>
            {
                return GetStudent(studentCode);
            });
        }

        public Task<Student?> GetStudentByStudentIDAsync(int studentID)
        {
            return Task.Factory.StartNew(
            () =>
            {
                return GetStudent(studentID);
            });
        }

        public async Task<Student?> GetStudentByUserID(int userID)
        {
            var student = await _schoolManagementSevice.StudentRepository.GetStudentByUserID(userID);
            if (student == null)
            {
                return student;
            }
            return student;
        }

        public async Task<int> GetStudentIDByStudentCodeAsync(string studentCode)
        {
            var student = await GetStudentByStudentCodeAsync(studentCode);
            if (student == null)
            {
                return 0;
            }
            return student.StudentId;
        }

        public async Task<ObservableCollection<Student>> GetStudentsByClass(int classID, int year)
        {
            var students = new ObservableCollection<Student>();
            var courses = await _courseService.GetCourseByClassID(classID, year);
            if (courses?.Any() == false)
            {
                return students;
            }
            foreach (var course in courses)
            {
                var student = GetStudent(course.StudentId);
                if (student == null)
                {
                    continue;
                }
                students.Add(student);
            }
            return students;
        }
    }
}