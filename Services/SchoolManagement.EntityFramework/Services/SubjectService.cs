using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class SubjectService : BaseService, ISubjectService
    {
        public async Task<Subject?> GetSubjectByID(int id)
        {
            return await _schoolManagementSevice.SubjectRepository.GetSubjectByID(id);
        }

        public async Task<ObservableCollection<Subject>> GetSubjectsBySize(int size, int page)
        {
            return await _schoolManagementSevice.SubjectRepository.GetRecordBySize(size, page);
        }
    }
}