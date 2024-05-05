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

        public async Task<ObservableCollection<User>> GetAccounts()
        {
            return await _schoolManagementSevice.UserRepository.GetAllAsync();
        }
        public async Task<ObservableCollection<User>> GetAccountsBySize(int size, int page)
        {
            return await _schoolManagementSevice.UserRepository.GetRecordBySize(size,page);
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