using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    internal interface IClassRepository<T> : IGenerateRepository<T> where T : class
    {
        T GetClassByID(int classID);

        ObservableCollection<T> GetAllClassesByID(IList<int> ids);
    }
}