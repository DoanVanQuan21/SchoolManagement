using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class StudentRepository : GenerateRepository<Student>, IStudentRepository<Student>
    {
        public StudentRepository(SchoolManagementContext context) : base(context)
        {
        }

        public Student? GetStudent(int studentID)
        {
            return FirstOrDefault(item => item.StudentId == studentID);
        }
    }
}