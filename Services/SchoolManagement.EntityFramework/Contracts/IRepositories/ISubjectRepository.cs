using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface ISubjectRepository : IGenerateRepository<Subject>
    {
        Task<Subject?> GetSubjectByID(int subjectID);
    }
}