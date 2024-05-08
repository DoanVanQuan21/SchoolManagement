using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly IUserService _userService;
        public TeacherService() : base()
        {
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
                _schoolManagementSevice.TeacherRepository.Add(teacher);
                return true;
            });
        }

        public async Task<Teacher?> GetTeacherByTeacherID(int teacherID)
        {
            var teacher =  await _schoolManagementSevice.TeacherRepository.GetTeacherByTeacherID(teacherID);
            if (teacher == null)
            {
                return teacher;
            }
            teacher.User = _userService.GetUser(teacher.UserId);
            return teacher;
        }

        public Teacher? GetTeacherInfo(int userID)
        {
            var teacher =  _schoolManagementSevice.TeacherRepository.GetTeacherInfo(userID);
            if (teacher == null)
            {
                return teacher;
            }
            teacher.User = _userService.GetUser(teacher.UserId);
            return teacher;
        }

        public Task<Teacher?> GetTeacherInfoAsync(int userID)
        {
            return Task.Factory.StartNew(() =>
            {
                return GetTeacherInfo(userID);
            });
        }

        public async Task<ObservableCollection<Teacher>> GetTeachers()
        {
            return await _schoolManagementSevice.TeacherRepository.GetAllAsync();
        }
    }
}