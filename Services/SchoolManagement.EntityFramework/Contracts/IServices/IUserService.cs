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

        (bool, User) Login(User user);

        bool RegisterAccount(User user);

        bool UpdateUserInfor(User user);
        string GetFullname(int userID);
        User? GetUser(int userID);
    }
}