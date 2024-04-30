using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface ISubjectService
    {
        Task<Subject?> GetSubjectByID(int id);
    }
}