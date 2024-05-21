using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Windows.Input;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    public class EditGradeSheetViewModel : BaseRegionViewModel
    {
        private readonly IGradeSheetService _gradeSheetService;
        private GradeSheet gradeSheet;

        public EditGradeSheetViewModel()
        {
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            GradeSheet = new GradeSheet();
            User = RootContext.CurrentUser;
        }

        public ICommand ClickedExit { get; set; }

        public ICommand ClickedUpdate { get; set; }

        public GradeSheet GradeSheet
        { get => gradeSheet; set { 
                SetProperty(ref gradeSheet, value); 
            } }

        public override string Title => "Sửa bảng điểm";

        public override User User { get; protected set; }

        protected override void RegisterCommand()
        {
            ClickedExit = new DelegateCommand(OnExit);
            ClickedUpdate = new DelegateCommand(OnUpdate);
            base.RegisterCommand();
        }

        private void OnExit()
        {
            CloseDialog();
        }

        private async void OnUpdate()
        {
            var isUpdated = await _gradeSheetService.UpdateGradeSheetAsync(GradeSheet);
            if (!isUpdated)
            {
                CloseDialog();
                NotificationManager.ShowWarning(Util.GetResourseString("UpdateGradeSheetFailed_Message"));
                return;
            }
            CloseDialog();
            NotificationManager.ShowSuccess(Util.GetResourseString("UpdateGradeSheetSuccess_Message"));
            EventAggregator.GetEvent<UpdateGradeSheetEvent>().Publish(GradeSheet);
        }
    }
}