using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IGradeSheetService
    {
        Task<ObservableCollection<GradeSheet>> GetGradeSheetsAsync(int subjectID, int classID);
        Task<ObservableCollection<GradeSheet>> GetAllGradeSheetByClassAndStudentID(int studentID, int classID);
        Task<bool> UpdateGradeSheetAsync(GradeSheet gradeSheet);
        Task<bool> UpdateOrAddRange(ObservableCollection<GradeSheet> gradeSheets);
    }
}