using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class GradeSheetService : IGradeSheetService
    {
        private readonly ISchoolManagementSevice _schoolManagementSevice;

        public GradeSheetService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
        }

        public ObservableCollection<GradeSheet> GetGradeSheets(int subjectID, int classID)
        {
            return _schoolManagementSevice.GradeSheetRepository.GetAllGradeSheet(subjectID, classID);
        }
    }
}