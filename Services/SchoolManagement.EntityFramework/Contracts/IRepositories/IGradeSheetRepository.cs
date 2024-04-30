using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface IGradeSheetRepository<T> : IGenerateRepository<T> where T : class
    {
        T? GetById(int subjectID, int classID);

        Task<bool> Update(T entity);

        Task<ObservableCollection<T>> GetAllGradeSheetAsync(int subjectID, int classID);

        bool Delete(int subjectID, int classID);
        Task<bool> UpdateOrAddRange(ObservableCollection<T> gradeSheets);
        Task<bool> UpdateByClassIDAndSubjectID(GradeSheet entity);
    }
}