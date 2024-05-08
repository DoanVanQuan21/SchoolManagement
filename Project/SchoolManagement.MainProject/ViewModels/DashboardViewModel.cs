using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.MainProject.ViewModels
{
    internal class DashboardViewModel : BaseRegionViewModel
    {
        private readonly IEditGradeSheetFormService _editFormService;
        private readonly ITeacherService _teacherService;
        public DashboardViewModel()
        {
            _editFormService = Ioc.Resolve<IEditGradeSheetFormService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
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
                return ;
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
            ClickedUnAcceptEditFormCommand = new DelegateCommand(OnUnAccept);
            ClickedAcceptEditFormCommand = new DelegateCommand(OnAccept);
            base.RegisterCommand();
        }

        private void OnAccept()
        {
        }

        private void OnUnAccept()
        {
        }
    }
}