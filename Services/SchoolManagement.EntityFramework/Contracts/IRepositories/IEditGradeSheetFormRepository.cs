using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface IEditGradeSheetFormRepository<T> : IGenerateRepository<T> where T : class
    {
        Task<ObservableCollection<T>> GetFormWaitting();
        Task<ObservableCollection<T>> GetFormWaittingByTeacherID(int teacherID);
    }
}