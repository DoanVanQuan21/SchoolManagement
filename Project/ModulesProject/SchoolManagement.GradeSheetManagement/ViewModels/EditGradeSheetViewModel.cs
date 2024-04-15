using Prism.Services.Dialogs;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    internal class EditGradeSheetViewModel : BaseRegionViewModel
    {
        private GradeSheet gradeSheet;

        public GradeSheet GradeSheet
        { get => gradeSheet; set { SetProperty(ref gradeSheet, value); } }

        public override string Title => "Sửa bảng điểm";

        public override User User { get; protected set; }

        public EditGradeSheetViewModel()
        {
            GradeSheet = new GradeSheet();
            User = RootContext.CurrentUser;
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var gradeSh = parameters.GetValue<GradeSheet>("GradeSheet");
            if (gradeSh == null)
            {
                return;
            }
            GradeSheet = gradeSh;
        }
    }
}