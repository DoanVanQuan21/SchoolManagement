using SchoolManagement.Core.Models.SchoolManagement;
using SchoolManagement.EntityFramework.Contracts;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace SchoolManagement.EntityFramework.Repositories
{
    public abstract class GenerateRepository<T> : IGenerateRepository<T> where T : class
    {
        protected readonly SchoolManagementContext _context;
        protected readonly ObservableCollection<T> _allItems;

        protected GenerateRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public T? Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Find(predicate);
        }

        public T? FirstOrDefault(Func<T, bool> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public ObservableCollection<T> GetAll()
        {
            if (_allItems == null)
            {
                return new ObservableCollection<T>();
            }
            _allItems.Clear();
            _allItems.AddRange(_context.Set<T>().ToList());
            return _allItems;
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
    }
}