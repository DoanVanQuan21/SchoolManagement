using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace SchoolManagement.EntityFramework.Repositories
{
    public abstract class GenerateRepository<T> : IGenerateRepository<T> where T : class
    {
        protected readonly ObservableCollection<T> _allItems;
        protected readonly SchoolManagementContext _context;

        protected GenerateRepository(SchoolManagementContext context)
        {
            _context = context;
            _context.SavingChanges += _context_SavingChanges;
            _allItems = new();
        }

        private void _context_SavingChanges(object? sender, Microsoft.EntityFrameworkCore.SavingChangesEventArgs e)
        {
            var t = 0;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public Task<bool> DeleteRecord(T entity)
        {
            return Task.Factory.StartNew(() =>
            {

                var record = _context.Set<T>().Remove(entity);
                if (record == null)
                {
                    return false;
                }
                _context.SaveChanges();
                return true;
            });

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

        public Task<ObservableCollection<T>> GetAllAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                return GetAll();
            });
        }

        public Task<ObservableCollection<T>> GetRecordBySize(int size, int page)
        {
            return Task.Factory.StartNew(() =>
            {
                if (_allItems == null)
                {
                    return new();
                }
                _allItems.Clear();
                var records = _context.Set<T>().ToList();
                if (records?.Any() == false)
                {
                    return new();
                }
                //if (records.Count < size * page)
                //{
                //    _allItems.AddRange(records);
                //    return _allItems;
                //}
                var countSkip = size * page - size;
                _allItems.AddRange(records.Skip(countSkip).Take(size));
                return _allItems;
            });
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
    }
}