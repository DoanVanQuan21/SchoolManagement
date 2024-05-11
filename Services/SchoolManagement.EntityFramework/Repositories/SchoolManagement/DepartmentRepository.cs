using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class DepartmentRepository : GenerateRepository<Department>
    {
        public DepartmentRepository(SchoolManagementContext context) : base(context)
        {
        }
    }
}