using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IStudentService
    {
        Student? GetStudent(int studentID);

        Student? GetStudent(string studentCode);

        Task<Student?> GetStudentByStudentCodeAsync(string studentCode);

        Task<Student?> GetStudentByStudentIDAsync(int studentID);

        Task<int> GetStudentIDByStudentCodeAsync(string studentCode);
    }
}