using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IEditGradeSheetFormService
    {
        Task<bool> AddForm(EditGradeSheetForm form);
        Task<ObservableCollection<EditGradeSheetForm>> GetFormWaitting();
        Task<ObservableCollection<EditGradeSheetForm>> GetFormWaittingByTeacherID(int teacherID);
    }
}