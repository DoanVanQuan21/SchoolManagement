using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface IUserService
    {
        (bool, User) Login(User user);
    }
}