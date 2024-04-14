using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface ICourseRepository<T> : IGenerateRepository<T> where T : class
    {
        ObservableCollection<T> GetCouseByTeacherID(int teacherID);

        ObservableCollection<T> GetCouseByClassID(int classID);
    }
}