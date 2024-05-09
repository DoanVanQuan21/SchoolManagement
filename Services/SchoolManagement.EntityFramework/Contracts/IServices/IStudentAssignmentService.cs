using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IStudentAssignmentService
    {
        Task<ObservableCollection<Student>> GetStudentsOfClassByYear(int classID, int year);
    }
}