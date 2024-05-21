using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService() : base()
        {
        }

        public Task<bool> AddUser(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                if (user == null)
                {
                    return false;
                }
                user.Username = user.FullName.ToLower();
                user.Password = $"{user.FullName}@{DateTime.Now.Year}";
                user.StartDate = DateTime.Now;
                user.LockAccount = false;
                _schoolManagementSevice.UserRepository.Add(user);
                return true;
            });
        }

        public Task<ObservableCollection<User>> GetAccountOfStudents()
        {
            return _schoolManagementSevice.UserRepository.GetAccountOfStudent();
        }

        public Task<ObservableCollection<User>> GetAccountOfTeachers()
        {
            return Task.Factory.StartNew(() =>
            {
                var accounts = new ObservableCollection<User>();
                var accountOfTeachers = _schoolManagementSevice.UserRepository.Where(s => s.Role == "teacher" && s.LockAccount == false);
                if (accountOfTeachers?.Any() == false)
                {
                    return accounts;
                }
                accounts.AddRange(accountOfTeachers);
                return accounts;
            });
        }

        public async Task<ObservableCollection<User>> GetAccounts()
        {
            return await _schoolManagementSevice.UserRepository.GetAllAsync();
        }

        public async Task<ObservableCollection<User>> GetAccountsBySize(int size, int page)
        {
            return await _schoolManagementSevice.UserRepository.GetRecordBySize(size, page);
        }

        public ObservableCollection<User> GetAllAccounts()
        {
            //TODO
            return _schoolManagementSevice.UserRepository.GetAll();
        }

        public ObservableCollection<User> GetAllStudentsByCourse(int classID, int subjectID)
        {
            //TODO
            var users = new ObservableCollection<User>();
            return users;
        }

        public string GetFullname(int userID)
        {
            return _schoolManagementSevice.UserRepository.GetFullname(userID);
        }

        public ObservableCollection<User> GetTeacherByDepartment(int departmentID)
        {
            //TODO
            return new();
        }

        public User? GetUser(int userID)
        {
            return _schoolManagementSevice.UserRepository.GetById(userID);
        }

        public Task<User?> GetUserAsync(int userID)
        {
            return Task.Factory.StartNew(() =>
            {
                return GetUser(userID);
            });
        }

        public async Task<bool> LockAccount(User user)
        {
            return await _schoolManagementSevice.UserRepository.LockAccount(user);
        }

        public (bool, User) Login(User user)
        {
            var currentUser = _schoolManagementSevice.UserRepository.FirstOrDefault(r => r.Username == user.Username && r.Password == user.Password);
            if (currentUser == null)
            {
                return (false, currentUser);
            }
            return (true, currentUser);
        }

        public bool RegisterAccount(User user)
        {
            var account = _schoolManagementSevice.UserRepository.FirstOrDefault(u => u.PhoneNumber == user.PhoneNumber);
            if (account != null)
            {
                return false;
            }
            _schoolManagementSevice.UserRepository.Add(user);
            return true;
        }

        public async Task<bool> UnLockAccount(User user)
        {
            return await _schoolManagementSevice.UserRepository.UnLockAccount(user);
        }

        public bool UpdateUserInfor(User user)
        {
            var userDb = _schoolManagementSevice.UserRepository.FirstOrDefault(u => u.UserId == user.UserId);
            if (userDb == null)
            {
                return false;
            }
            _schoolManagementSevice.UserRepository.Update(user);
            return true;
        }
    }
}