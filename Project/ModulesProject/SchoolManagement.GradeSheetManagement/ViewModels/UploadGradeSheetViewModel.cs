using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Windows.Input;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    internal class UploadGradeSheetViewModel : BaseRegionViewModel
    {
        private bool dataLoaded = false;

        public override string Title => "Upload file";

        public override User User { get; protected set; }

        public UploadGradeSheetViewModel()
        {
            User = RootContext.CurrentUser;
        }

        public bool DataLoaded
        { get => dataLoaded; set { SetProperty(ref dataLoaded, value); } }

        public ICommand ClickedUploadFile { get; set; }

        protected override void RegisterCommand()
        {
            ClickedUploadFile = new DelegateCommand(OnUpload);
            base.RegisterCommand();
        }

        private void OnUpload()
        {
        }
    }
}