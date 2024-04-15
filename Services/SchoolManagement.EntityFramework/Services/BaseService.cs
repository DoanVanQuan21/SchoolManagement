using SchoolManagement.Core.avalonia;
using SchoolManagement.EntityFramework.Contracts;

namespace SchoolManagement.EntityFramework.Services
{
    public abstract class BaseService
    {
        protected readonly ISchoolManagementSevice _schoolManagementSevice;

        protected BaseService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
        }
    }
}