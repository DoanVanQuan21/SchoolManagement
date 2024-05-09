using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Events;
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

        public override string Title => "Trang chủ";

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
            var teacher = await _teacherService.GetTeacherInfoAsync(User.UserId);
            if (teacher == null)
            {
                return;
            }
            if (User.Role == "teacher")
            {
                forms = await _editFormService.GetFormWaittingByTeacherID(teacher.TeacherId);
                FormsNeedToConfirm.AddRange(forms);
                return;
            }
            forms = await _editFormService.GetFormWaitting();
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
                NotificationManager.ShowWarning("Không thể xác nhận đơn sửa điểm!.");
                return;
            }
            var isUnLocked = await _gradeSheetService.UnLock(editForm.GradeSheetId);
            if (!isUnLocked)
            {
                NotificationManager.ShowWarning("Không thể mở khóa sửa bảng điểm!.");
                return;
            }
            FormsNeedToConfirm.Remove(editForm);
            NotificationManager.ShowSuccess("Bảng điểm đã được mở khóa!.");
            return;
        }

        private void OnUnAccept(object form)
        {
        }
    }
}