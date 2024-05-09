using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IClassService
    {
        Task<bool> AddClass(Class _class);
        Task<bool> DeleteClass(int classID);
        Task<ObservableCollection<Class>> GetAllClassesByID(IList<int> ids);
        Task<Class> GetClassByID(int classID);
        Task<ObservableCollection<Class>> GetClassesBySize(int size, int page);
    }
}