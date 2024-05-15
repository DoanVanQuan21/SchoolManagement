using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUserService _userService;
        private ISchoolManagementSevice _schoolManagementSevice;

        public TeacherService() : base()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
            _userService = Ioc.Resolve<IUserService>();
        }

        public Task<bool> AddTeacher(Teacher teacher)
        {
            return Task.Factory.StartNew(() =>
            {
                if (teacher == null)
                {
                    return false;
                }
                var teachers = _schoolManagementSevice.TeacherRepository.GetAll();
                if (teachers?.Any() == false)
                {
                    teacher.TeacherCode = $"GV{DateTime.Now.Year}1";
                    _schoolManagementSevice.TeacherRepository.Add(teacher);
                    return true;
                }
                var lastTeacher = teachers.LastOrDefault();
                teacher.TeacherCode = $"GV{DateTime.Now.Year}{(lastTeacher == null ? 1 : (lastTeacher.TeacherId + 1))}";
                _schoolManagementSevice.TeacherRepository.Add(teacher);
                return true;
            });
        }

        public async Task<Teacher?> GetTeacherByTeacherID(int teacherID)
        {
            var teacher = await _schoolManagementSevice.TeacherRepository.GetTeacherByTeacherID(teacherID);
            if (teacher == null)
            {
                return teacher;
            }
            teacher.User = _userService.GetUser(teacher.UserId);
            return teacher;
        }

        public async Task<Teacher?> GetTeacherByUserID(int userID)
        {
            var teacher = await _schoolManagementSevice.TeacherRepository.GetTeacherByUserID(userID);
            if (teacher == null)
            {
                return teacher;
            }
            teacher.User = _userService.GetUser(teacher.UserId);
            return teacher;
        }

        public async Task<ObservableCollection<Teacher>> GetTeachers()
        {
            return await _schoolManagementSevice.TeacherRepository.GetAllAsync();
        }

        public async Task<ObservableCollection<Teacher>> GetTeachersBySize(int size, int page)
        {
            return await _schoolManagementSevice.TeacherRepository.GetRecordBySize(size, page);
        }

        public async Task<ObservableCollection<Teacher>> GetTeachersBySubjectID(int subjectID)
        {
            var teachers = new ObservableCollection<Teacher>();
            var ts = _schoolManagementSevice.TeacherRepository.Where(t => t.SubjectId == subjectID);
            if (ts?.Any() == false)
            {
                return teachers;
            }
            foreach (var t in ts)
            {
                t.User = await _userService.GetUserAsync(t.UserId);
            }
            teachers.AddRange(ts);
            return teachers;
        }
    }
}