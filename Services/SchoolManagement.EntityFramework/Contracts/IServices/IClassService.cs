using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IClassService
    {
        Class GetClassByID(int classID);
        Task<Class> GetClassByIDAsync(int classID);

        ObservableCollection<Class> GetAllClassesByID(IList<int> ids);
        Task<ObservableCollection<Class>> GetAllClassesByIDAsync(IList<int> ids);
    }
}