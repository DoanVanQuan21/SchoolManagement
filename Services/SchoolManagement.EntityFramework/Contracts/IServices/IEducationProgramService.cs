using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IEducationProgramService
    {
        Task<EducationProgram?> GetEducationProgram(int educationID);

        Task<ObservableCollection<EducationProgram>> GetEdicationPrograms();
        Task<ObservableCollection<EducationProgram>> GetEdicationPrograms(string status);
    }
}