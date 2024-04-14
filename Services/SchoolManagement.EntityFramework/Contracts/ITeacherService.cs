using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface ITeacherService
    {
        Teacher? GetTeacherInfo(int userID);
    }
}