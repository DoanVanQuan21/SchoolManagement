using SchoolManagement.Core.Repositories.SchoolManagement;

namespace SchoolManagement.Core.Contracts
{
    public interface ISchoolManagementSevice
    {
        UserRepository UserRepository { get; }
    }
}