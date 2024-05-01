using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class StudentService : BaseService, IStudentService
    {
        private readonly IUserService _userService;
        private readonly IClassService _classService;
        public StudentService() : base()
        {
            _userService = Ioc.Resolve<IUserService>();
            _classService = Ioc.Resolve<IClassService>();
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
            student.Class = await _classService.GetClassByIDAsync(student.ClassId);
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

        public async Task<ObservableCollection<Student>> GetStudentsByClass(int classID)
        {
            var students = await _schoolManagementSevice.StudentRepository.GetStudentsByClass(classID);
            foreach (var student in students)
            {
                student.User = _userService.GetUser(student.UserId);
                student.Class = _classService.GetClassByID(student.ClassId);
            }
            return students;
        }
    }
}