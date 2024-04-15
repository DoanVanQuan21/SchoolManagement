using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IStudentService
    {
        Student? GetStudent(int studentID);
    }
}