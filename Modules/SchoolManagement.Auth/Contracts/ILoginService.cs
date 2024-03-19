using SchoolManagement.Core.Models;

namespace SchoolManagement.Auth.Contracts
{
    internal interface ILoginService
    {
        bool Login(User user);
    }
}