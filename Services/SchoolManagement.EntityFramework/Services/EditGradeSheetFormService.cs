using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class EditGradeSheetFormService : IEditGradeSheetFormService
    {
        private readonly IGradeSheetService _gradeSheetService;
        private readonly ITeacherService _teacherService;
        private readonly ISchoolManagementSevice _schoolManagementSevice;

        public EditGradeSheetFormService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();

            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
        }

        public async Task<bool> Accepted(EditGradeSheetForm form)
        {
            return await _schoolManagementSevice.EditGradeSheetFormRepository.Accepted(form);
        }

        public Task<bool> AddForm(EditGradeSheetForm form)
        {
            return Task.Factory.StartNew(() =>
            {
                _schoolManagementSevice.EditGradeSheetFormRepository.Add(form);
                return true;
            });
        }

        public async Task<ObservableCollection<EditGradeSheetForm>> GetFormWaitting()
        {
            var forms = await _schoolManagementSevice.EditGradeSheetFormRepository.GetFormWaitting();
            await GetDetailEditForm(forms);

            return forms;
        }

        public async Task<ObservableCollection<EditGradeSheetForm>> GetFormWaittingByTeacherID(int teacherID)
        {
            var forms = await _schoolManagementSevice.EditGradeSheetFormRepository.GetFormWaittingByTeacherID(teacherID);
            await GetDetailEditForm(forms);
            return forms;
        }

        public async Task<bool> UnAccepted(EditGradeSheetForm form)
        {
            return await _schoolManagementSevice.EditGradeSheetFormRepository.UnAccepted(form);
        }

        private async Task GetDetailEditForm(ObservableCollection<EditGradeSheetForm> forms)
        {
            foreach (var form in forms)
            {
                form.GradeSheet = await _gradeSheetService.GetGradeSheet(form.GradeSheetId);
                form.Teacher = await _teacherService.GetTeacherByTeacherID(form.TeacherId);
            }
        }
    }
}