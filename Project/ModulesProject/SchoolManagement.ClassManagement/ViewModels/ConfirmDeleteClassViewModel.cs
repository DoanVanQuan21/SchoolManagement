using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Windows.Input;

namespace SchoolManagement.ClassManagement.ViewModels
{
    public class ConfirmDeleteClassViewModel : BaseRegionViewModel
    {
        public override string Title => Util.GetResourseString("ConfirmDeleteClass_Label");

        public override User User { get; protected set; }

        public ICommand ClickedExit { get; set; }
        public ICommand ClickedOK { get; set; }
        public Action OnOK { get; set; }

        protected override void RegisterCommand()
        {
            ClickedExit = new DelegateCommand(OnExit);
            ClickedOK = new DelegateCommand(OnClickedOk);
            base.RegisterCommand();
        }

        private void OnClickedOk()
        {
            OnOK?.Invoke();
        }

        private void OnExit()
        {
            CloseDialog();
        }
    }
}