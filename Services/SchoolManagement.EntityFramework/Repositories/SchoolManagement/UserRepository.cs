using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class UserRepository : GenerateRepository<User>, IUserRepository<User>
    {
        
        public UserRepository(SchoolManagementContext context) : base(context)
        {
        }

        public bool Delete(int id)
        {
            var user = GetById(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(item => item.UserId == id);
        }

        public string GetFullname(int id)
        {
            var user = FirstOrDefault(item => item.UserId == id);
            if (user == null)
            {
                return string.Empty;
            }
            return $"{user.FirstName} {user.LastName}";
        }

        public bool Update(User entity)
        {
            var user = GetById(entity.UserId);
            if (user == null)
            {
                return false;
            }
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            user.PhoneNumber = entity.PhoneNumber;
            user.DateOfBirth = entity.DateOfBirth;
            user.Address = entity.Address;
            _context.SaveChanges();
            return true;
        }

        public bool UpdateStatus(User entity)
        {
            return Update(entity);
        }
        public Task<bool> LockAccount(User entity)
        {
            return Task.Factory.StartNew(() => {
                var user = _context.Users.FirstOrDefault(u=>u.UserId == entity.UserId);
                if (user == null)
                {
                    return false;
                }
                user.LockAccount = true;
                _context.SaveChanges();
                return true;
            });
        }
        public Task<bool> UnLockAccount(User entity)
        {
            return Task.Factory.StartNew(() => {
                var user = _context.Users.FirstOrDefault(u => u.UserId == entity.UserId);
                if (user == null)
                {
                    return false;
                }
                user.LockAccount = false;
                _context.SaveChanges();
                return true;
            });
        }
        public Task<ObservableCollection<User>> GetAccountOfStudent()
        {
            return Task.Factory.StartNew(() =>
            {
                _allItems.Clear();
                var accountOfStudents = Where(s => s.Role == "student" && s.LockAccount == false);
                if (accountOfStudents?.Any() == false)
                {
                    return _allItems;
                }
                _allItems.AddRange(accountOfStudents);
                return _allItems;
            });
        }
    }
}