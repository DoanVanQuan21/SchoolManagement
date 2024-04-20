using SchoolManagement.ApiService.Contracts;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.ApiService.Services
{
    public class UserService : BaseService, IUserService
    {
        public async Task<(bool, User?)> Login(string username, string password)
        {
            string url = $"https://localhost:7181/api/login?username={username}&password={password}";
            var user = await GetResponse<User>(url);
            if (user == null)
            {
                return (false, null);
            }
            return (true, user);
        }
    }
}