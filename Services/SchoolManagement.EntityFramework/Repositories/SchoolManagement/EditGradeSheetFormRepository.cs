using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class EditGradeSheetFormRepository : GenerateRepository<EditGradeSheetForm>, IEditGradeSheetFormRepository<EditGradeSheetForm>
    {
        private readonly ObservableCollection<EditGradeSheetForm> _forms = new();

        public EditGradeSheetFormRepository(SchoolManagementContext context) : base(context)
        {
        }

        public Task<ObservableCollection<EditGradeSheetForm>> GetFormWaitting()
        {
            return Task.Factory.StartNew(() =>
            {
                _forms.Clear();
                var forms = Where(f => f.Status == AceptFormStatus.Waitting.ToString());
                if (forms?.Any() == false)
                {
                    return _forms;
                }
                _forms.AddRange(forms);
                return _forms;
            });
        }

        public Task<ObservableCollection<EditGradeSheetForm>> GetFormWaittingByTeacherID(int teacherID)
        {
            return Task.Factory.StartNew(() =>
            {
                _forms.Clear();
                var forms = Where(f => f.Status == AceptFormStatus.Waitting.ToString() && f.TeacherId == teacherID);
                if (forms?.Any() == false)
                {
                    return _forms;
                }
                _forms.AddRange(forms);
                return _forms;
            });
        }
    }
}