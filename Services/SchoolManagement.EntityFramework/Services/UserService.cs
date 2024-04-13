using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class UserService : IUserService
    {
        private readonly ISchoolManagementSevice _schoolManagementSevice;

        public UserService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
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

        public ObservableCollection<User> GetTeacherByDepartment(int departmentID)
        {
            //TODO
            return new();
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