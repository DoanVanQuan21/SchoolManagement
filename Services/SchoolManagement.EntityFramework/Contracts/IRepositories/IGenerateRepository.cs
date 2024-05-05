using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface IGenerateRepository<T> where T : class
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        T? Find(Func<T, bool> predicate);

        T? FirstOrDefault(Func<T, bool> predicate);

        ObservableCollection<T> GetAll();
        Task<ObservableCollection<T>> GetAllAsync();
        Task<ObservableCollection<T>> GetRecordBySize(int size, int page);
        IEnumerable<T> Where(Func<T, bool> predicate);
    }
}