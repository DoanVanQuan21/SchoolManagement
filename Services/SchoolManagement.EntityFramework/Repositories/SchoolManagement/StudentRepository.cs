using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class StudentRepository : GenerateRepository<Student>, IStudentRepository<Student>
    {
        private readonly ObservableCollection<Student> _students = new();

        public StudentRepository(SchoolManagementContext context) : base(context)
        {
        }
    }
}