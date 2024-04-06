using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface IGenerateRepository<T> where T : class
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        ObservableCollection<T> GetAll();

        T? Find(Func<T, bool> predicate);

        T? FirstOrDefault(Func<T, bool> predicate);

        IEnumerable<T> Where(Func<T, bool> predicate);
    }
}