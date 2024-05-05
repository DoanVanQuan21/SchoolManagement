using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class TeacherService : BaseService, ITeacherService
    {
        public TeacherService() : base()
        {
        }

        public async Task<Teacher?> GetTeacherByTeacherID(int teacherID)
        {
            return await _schoolManagementSevice.TeacherRepository.GetTeacherByTeacherID(teacherID);
        }

        public Teacher? GetTeacherInfo(int userID)
        {
            return _schoolManagementSevice.TeacherRepository.GetTeacherInfo(userID);
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