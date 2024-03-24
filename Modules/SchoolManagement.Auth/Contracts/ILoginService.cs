using SchoolManagement.Core.Models.SchoolManagement;

namespace SchoolManagement.Auth.Contracts
{
    internal interface ILoginService
    {
        bool Login(User user);
    }
}