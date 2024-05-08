﻿using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class EditGradeSheetFormService : BaseService, IEditGradeSheetFormService
    {
        private readonly IGradeSheetService _gradeSheetService;
        private readonly ITeacherService _teacherService;

        public EditGradeSheetFormService()
        {
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
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

        private async Task GetDetailEditForm(ObservableCollection<EditGradeSheetForm> forms)
        {
            foreach (var form in forms)
            {
                form.GradeSheet = await _gradeSheetService.GetGradeSheetByGradeSheetID(form.GradeSheetId);
                form.Teacher = await _teacherService.GetTeacherByTeacherID(form.TeacherId);
            }
        }
    }
}