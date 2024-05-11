using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class TeacherRepository : GenerateRepository<Teacher>, ITeacherRepository<Teacher>
    {
        public TeacherRepository(SchoolManagementContext context) : base(context)
        {
        }

        public Task<Teacher?> GetTeacherByTeacherID(int teacherID)
        {
            return Task.Factory.StartNew(() =>
            {
                return FirstOrDefault(item => item.TeacherId == teacherID);
            });
        }

        public Task<Teacher?> GetTeacherByUserID(int userID)
        {
            return Task.Factory.StartNew(() =>
            {
                return FirstOrDefault(item => item.UserId == userID);
            });
        }

    }
}