using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IUserService
    {
        ObservableCollection<User> GetAllAccounts();

        Task<ObservableCollection<User>> GetAccounts();

        Task<ObservableCollection<User>> GetAccountsBySize(int size, int page);

        ObservableCollection<User> GetAllStudentsByCourse(int classID, int subjectID);

        ObservableCollection<User> GetTeacherByDepartment(int departmentID);
        Task<ObservableCollection<User>> GetAccountOfStudents();
        Task<ObservableCollection<User>> GetAccountOfTeachers();
        Task<(bool, User?)> Login(User user);

        bool RegisterAccount(User user);

        bool UpdateUserInfor(User user);

        string GetFullname(int userID);

        User? GetUser(int userID);

        Task<User?> GetUserAsync(int userID);
        Task<bool> AddUser(User user);
        Task<bool> LockAccount(User user);
        Task<bool> UnLockAccount(User user);
        Task<bool> ChangePassword(User user);
        Task<bool> ResetPassword(User user);
    }
}