using SchoolManagement.EntityFramework.Repositories.SchoolManagement;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface ISchoolManagementSevice
    {
        UserRepository UserRepository { get; }
    }
}