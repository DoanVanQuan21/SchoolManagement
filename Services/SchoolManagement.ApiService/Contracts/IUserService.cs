using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.ApiService.Contracts
{
    public interface IUserService : IBaseService
    {
        Task<(bool, User?)> Login(string username, string password);
    }
}