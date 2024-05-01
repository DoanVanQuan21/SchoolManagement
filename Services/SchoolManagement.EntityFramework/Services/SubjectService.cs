using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;

namespace SchoolManagement.EntityFramework.Services
{
    public class SubjectService : BaseService, ISubjectService
    {
        public async Task<Subject?> GetSubjectByID(int id)
        {
            return await _schoolManagementSevice.SubjectRepository.GetSubjectByID(id);
        }
    }
}