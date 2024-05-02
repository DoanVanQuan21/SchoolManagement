using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface ICourseRepository<T> : IGenerateRepository<T> where T : class
    {
        ObservableCollection<T> GetCouseByTeacherID(int teacherID);

        Task<ObservableCollection<T>> GetCouseByClassID(int classID);
        Task<T?> GetCouseByClassAndSubjectID(int classID,int subjectID,int year);
        List<int> GetClassIDs(int teacherID);
    }
}