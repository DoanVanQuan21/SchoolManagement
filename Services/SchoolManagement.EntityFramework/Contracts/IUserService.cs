using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface IUserService
    {
        (bool, User) Login(User user);

        bool RegisterAccount(User user);

        ObservableCollection<User> GetAllAccounts();

        ObservableCollection<User> GetAllStudentsByCourse(int classID, int subjectID);

        ObservableCollection<User> GetTeacherByDepartment(int departmentID);
    }
}