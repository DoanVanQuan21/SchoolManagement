using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts
{
    internal interface IClassRepository<T> : IGenerateRepository<T> where T : class
    {
        T GetClassByID(int classID);

        ObservableCollection<T> GetAllClassesByID(IList<T> ids);
    }
}