using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface ICourseRepository<T> : IGenerateRepository<T> where T : class
    {
        ObservableCollection<T> GetCouseByTeacherID(int teacherID);

        Task<ObservableCollection<T>> GetCouseByClassID(int classID);

        Task<T?> GetCouseByClassAndSubjectID(int classID, int subjectID, int year);

        List<int> GetClassIDs(int teacherID, int year);

        Task<ObservableCollection<T>> GetCourseByClassID(int classID, int year);

        Task<ObservableCollection<Course>> GetQuantityByStudent(int studentID,int year);
    }
}