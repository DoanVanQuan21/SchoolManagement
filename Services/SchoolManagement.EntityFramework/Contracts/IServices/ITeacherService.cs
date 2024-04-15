using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface ITeacherService
    {
        Teacher? GetTeacherInfo(int userID);
    }
}