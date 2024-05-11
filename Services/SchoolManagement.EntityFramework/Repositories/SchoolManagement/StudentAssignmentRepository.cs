using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class StudentAssignmentRepository : GenerateRepository<StudentAssignment>, IStudentAssignmentRepository<StudentAssignment>
    {
        private readonly ObservableCollection<StudentAssignment> _studentAssignments;

        public StudentAssignmentRepository(SchoolManagementContext context) : base(context)
        {
            _studentAssignments = new();
        }

        public Task<ObservableCollection<StudentAssignment>> GetStudentAssignsOfClassByYear(int classID, int year)
        {
            return Task.Factory.StartNew(() =>
            {
                _studentAssignments.Clear();
                var studentAssigns = Where(s => s.ClassId == classID && s.StartDate.Year == year);
                var t = GetAll();
                if (studentAssigns?.Any() == false)
                {
                    return _studentAssignments;
                }
                _studentAssignments.AddRange(studentAssigns);
                return _studentAssignments;
            });
        }
    }
}