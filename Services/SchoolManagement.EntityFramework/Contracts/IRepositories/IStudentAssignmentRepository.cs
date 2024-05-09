using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    internal interface IStudentAssignmentRepository<T> : IGenerateRepository<T> where T : class
    {
        Task<ObservableCollection<StudentAssignment>> GetStudentAssignsOfClassByYear(int classID, int year);
    }
}