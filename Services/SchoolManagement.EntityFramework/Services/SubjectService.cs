using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class SubjectService : BaseService, ISubjectService
    {
        public SubjectService() : base()
        {
        }

        public Task<Subject?> GetSubject(int subjectID)
        {
            return Task.Factory.StartNew(() =>
            {
                return _schoolManagementSevice.SubjectRepository.FirstOrDefault(s => s.SubjectId == subjectID);
            });
        }

        public async Task<Subject?> GetSubjectByID(int id)
        {
            return await _schoolManagementSevice.SubjectRepository.GetSubjectByID(id);
        }

        public Task<ObservableCollection<Subject>> GetSubjects()
        {
            return _schoolManagementSevice.SubjectRepository.GetAllAsync();
        }

        public async Task<ObservableCollection<Subject>> GetSubjectsBySize(int size, int page)
        {
            return await _schoolManagementSevice.SubjectRepository.GetRecordBySize(size, page);
        }
    }
}