using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IGradeSheetService
    {
        ObservableCollection<GradeSheet> GetGradeSheets(int subjectID, int classID);
    }
}