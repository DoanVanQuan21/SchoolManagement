using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface IStudentRepository<T> : IGenerateRepository<T> where T : class
    {
        T? GetStudent(int studentID);
        T? GetStudent(string studentCode);
        Task<T?> GetStudentByUserID(int userID);
        Task<ObservableCollection<Student>> GetStudentsByClass(int classID);
    }
}