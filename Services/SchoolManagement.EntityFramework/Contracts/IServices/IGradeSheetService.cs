using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Services;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IGradeSheetService
    {
        Task<GradeSheet?> GetGradeSheet(int gradeSheetID);

        Task<ObservableCollection<GradeSheet>> GetGradeSheetOfSubjectByClass(int courseID);

        Task<ObservableCollection<GradeSheet>> FinishEditGradeSheet(ObservableCollection<GradeSheet> gradeSheets);

        Task<bool> UnLock(int gradeSheetID);

        Task<bool> UpdateGradeSheetAsync(GradeSheet gradeSheet);

        Task<ObservableCollection<GradeSheet>> GetGradeSheetsByStudentID(int studentID);
        Task<ObservableCollection<GradeSheet>> GetGradeSheetsByStudentID(int studentID, int year);
        Task<bool> UpdateOrAddRange(ObservableCollection<GradeSheet> gradeSheets);  
    }
}