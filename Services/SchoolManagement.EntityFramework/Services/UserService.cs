using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;

namespace SchoolManagement.EntityFramework.Services
{
    public class UserService : IUserService
    {
        private readonly ISchoolManagementSevice _schoolManagementSevice;

        public UserService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
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
    }
}