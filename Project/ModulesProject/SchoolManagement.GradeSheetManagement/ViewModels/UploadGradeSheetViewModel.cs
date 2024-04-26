using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    public class UploadGradeSheetViewModel : BaseRegionViewModel
    {
        private bool dataLoaded = false;
        private ObservableCollection<GradeSheet> gradeSheets;

        public override string Title => "Upload file";

        public override User User { get; protected set; }

        public UploadGradeSheetViewModel()
        {
            User = RootContext.CurrentUser;
            GradeSheets = new();
        }

        public bool DataLoaded
        { get => dataLoaded; set { SetProperty(ref dataLoaded, value); } }

        public ObservableCollection<GradeSheet> GradeSheets
        { get => gradeSheets; set { SetProperty(ref gradeSheets, value); } }

        public ICommand ClickedUploadFile { get; set; }
        public ICommand ClickedExit { get; set; }
        public ICommand ClickedOK { get;set; }
        protected override void RegisterCommand()
        {
            ClickedUploadFile = new DelegateCommand(OnUpload);
            ClickedExit = new DelegateCommand(OnExit);
            ClickedOK = new DelegateCommand(OnOK);
            base.RegisterCommand();
        }

        private void OnOK()
        {
            CloseDialog();
        }

        private void OnExit()
        {
            CloseDialog();
        }

        private void OnUpload()
        {
        }
    }
}