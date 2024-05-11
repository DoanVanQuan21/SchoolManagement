using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface ITeacherService
    {
        Task<Teacher?> GetTeacherByUserID(int userID);
        Task<Teacher?> GetTeacherByTeacherID(int teacherID);
        Task<ObservableCollection<Teacher>> GetTeachers();
        Task<ObservableCollection<Teacher>> GetTeachersBySubjectID(int subjectID);
        Task<ObservableCollection<Teacher>> GetTeachersBySize(int size, int page);
        Task<bool> AddTeacher(Teacher teacher);
    }
}