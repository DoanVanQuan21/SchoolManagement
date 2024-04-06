using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.Auth.Contracts
{
    internal interface ILoginService
    {
        bool Login(User user);
    }
}