using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class EducationProgramService : IEducationProgramService
    {
        private readonly ISchoolManagementSevice _schoolManagementSevice;

        public EducationProgramService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
        }

        public async Task<ObservableCollection<EducationProgram>> GetEdicationPrograms()
        {
            return await _schoolManagementSevice.EducationProgramRepository.GetAllAsync();
        }

        public Task<ObservableCollection<EducationProgram>> GetEdicationPrograms(string status)
        {
            return Task.Factory.StartNew(() => {
                var educationPrograms= new ObservableCollection<EducationProgram>();
                var eds = _schoolManagementSevice.EducationProgramRepository.Where(e=>e.Status == status);
                if(eds?.Any()==false)
                {
                    return educationPrograms;
                }
                educationPrograms.AddRange(eds);
                return educationPrograms;
            });
        }

        public Task<EducationProgram?> GetEducationProgram(int educationID)
        {
            return Task.Factory.StartNew(() => {

                return _schoolManagementSevice.EducationProgramRepository.FirstOrDefault(e => e.EducationProgramId == educationID);
            });
        }
    }
}