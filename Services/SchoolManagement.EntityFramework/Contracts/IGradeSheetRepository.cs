using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface IGradeSheetRepository<T> : IGenerateRepository<T> where T : class
    {
        T? GetById(int subjectID, int classID);

        bool Update(T entity);

        ObservableCollection<T> GetAllGradeSheet(int subjectID, int classID);

        bool Delete(int subjectID, int classID);
    }
}