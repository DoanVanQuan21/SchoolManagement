using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.MainProject.ViewModels
{
    internal class DashboardViewModel : BaseRegionViewModel
    {
        private readonly IEditGradeSheetFormService _editFormService;
        private readonly IGradeSheetService _gradeSheetService;
        private readonly ITeacherService _teacherService;

        public DashboardViewModel()
        {
            _editFormService = Ioc.Resolve<IEditGradeSheetFormService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            User = RootContext.CurrentUser;
            FormsNeedToConfirm = new();
            GetFormWaitting();
        }

        public override string Title => Util.GetResourseString("Home_Label");

        public override User User { get; protected set; }
        public ObservableCollection<EditGradeSheetForm> FormsNeedToConfirm { get; set; }

        private async void GetFormWaitting()
        {
            if (User.Role == "student")
            {
                return;
            }
            FormsNeedToConfirm.Clear();
            var forms = new ObservableCollection<EditGradeSheetForm>();

            if (User.Role == "admin")
            {
                forms = await _editFormService.GetFormWaitting();
                FormsNeedToConfirm.AddRange(forms);

                return;
            }
            var teacher = await _teacherService.GetTeacherByUserID(User.UserId);
            if (teacher == null)
            {
                return;
            }
            forms = await _editFormService.GetFormWaittingByTeacherID(teacher.TeacherId);
            FormsNeedToConfirm.AddRange(forms);
        }

        public ICommand ClickedAcceptEditFormCommand { get; set; }
        public ICommand ClickedUnAcceptEditFormCommand { get; set; }

        protected override void RegisterCommand()
        {
            ClickedUnAcceptEditFormCommand = new DelegateCommand<object>(OnUnAccept);
            ClickedAcceptEditFormCommand = new DelegateCommand<object>(OnAccept);
            base.RegisterCommand();
        }

        private async void OnAccept(object form)
        {
            var editForm = form as EditGradeSheetForm;
            var isAccepted = await _editFormService.Accepted(editForm);
            if (!isAccepted)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("UnableConfirmEditGradeSheetForm_Message"));
                return;
            }
            var isUnLocked = await _gradeSheetService.UnLock(editForm.GradeSheetId);
            if (!isUnLocked)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("UnLockEditGradeSheetError_Message"));
                return;
            }
            FormsNeedToConfirm.Remove(editForm);
            NotificationManager.ShowSuccess(Util.GetResourseString("UnLockEditGradeSheetSuccess_Message"));
            return;
        }

        private void OnUnAccept(object form)
        {
        }
    }
}