using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class EducationProgramRepository : GenerateRepository<EducationProgram>
    {
        public EducationProgramRepository(SchoolManagementContext context) : base(context)
        {
        }
    }
}