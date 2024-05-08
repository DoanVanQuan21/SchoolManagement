using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Windows.Input;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    public class RequestEditGradeSheetViewModel : BaseRegionViewModel
    {
        private EditGradeSheetForm editGradeSheetForm;

        public override string Title => "Đơn yêu cầu sửa điểm";

        public override User User { get; protected set; }

        public RequestEditGradeSheetViewModel()
        {
            User = RootContext.CurrentUser;
        }

        public ICommand ClickedExit { get; set; }
        public ICommand ClickedOK { get; set; }
        public Action<EditGradeSheetForm> SendRequest { get; set; }
        public EditGradeSheetForm EditGradeSheetForm { get => editGradeSheetForm; set => SetProperty(ref editGradeSheetForm, value); }

        protected override void RegisterCommand()
        {
            ClickedExit = new DelegateCommand(OnExit);
            ClickedOK = new DelegateCommand(OnOK);
            base.RegisterCommand();
        }

        private void OnOK()
        {
            SendRequest?.Invoke(EditGradeSheetForm);
        }

        private void OnExit()
        {
            CloseDialog();
        }
    }
}