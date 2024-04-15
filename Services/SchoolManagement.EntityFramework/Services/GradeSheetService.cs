using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class GradeSheetService :BaseService, IGradeSheetService
    {

        public GradeSheetService() : base()
        {
        }

        public ObservableCollection<GradeSheet> GetGradeSheets(int subjectID, int classID)
        {
            return _schoolManagementSevice.GradeSheetRepository.GetAllGradeSheet(subjectID, classID);
        }
    }
}