using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class SubjectRepository : GenerateRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(SchoolManagementContext context) : base(context)
        {
        }

        public Task<Subject?> GetSubjectByID(int subjectID)
        {
            return Task.Factory.StartNew(() =>
                {
                    return FirstOrDefault(s => s.SubjectId == subjectID);
                });
        }
    }
}