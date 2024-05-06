using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface ITeacherService
    {
        Teacher? GetTeacherInfo(int userID);
        Task<Teacher?> GetTeacherInfoAsync(int userID);
        Task<Teacher?> GetTeacherByTeacherID(int teacherID);
        Task<ObservableCollection<Teacher>> GetTeachers();
        Task<bool> AddTeacher(Teacher teacher);
    }
}