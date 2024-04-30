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

        public Student? GetStudent(int studentID)
        {
            return FirstOrDefault(item => item.StudentId == studentID);
        }

        public Student? GetStudent(string studentCode)
        {
            return FirstOrDefault(item => item.StudentCode == studentCode);
        }

        public Task<ObservableCollection<Student>> GetStudentsByClass(int classID)
        {
            return Task.Factory.StartNew(() =>
            {
                _students.Clear();
                var students = Where(s => s.ClassId == classID);
                if (students?.Any() == false)
                {
                    return _students;
                }
                _students.AddRange(students);
                return _students;
            });
        }
    }
}