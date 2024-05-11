using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface ISubjectService
    {
        Task<ObservableCollection<Subject>> GetSubjectsBySize(int size, int page);
        Task<ObservableCollection<Subject>> GetSubjects();
        Task<Subject?> GetSubject(int subjectID);
    }
}