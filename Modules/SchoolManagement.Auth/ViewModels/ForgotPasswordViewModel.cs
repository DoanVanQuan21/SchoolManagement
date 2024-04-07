using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Windows.Input;

namespace SchoolManagement.Auth.ViewModels
{
    internal class ForgotPasswordViewModel : BaseRegionViewModel
    {
        public override string Title => "Forgot password";

        public ForgotPasswordViewModel()
        {
        }
        public ICommand SendRequestChangePasswordCommand { get; set; }
        public ICommand ClickedPreviewMainViewCommand { get; set; }

        protected override void RegisterCommand()
        {
            SendRequestChangePasswordCommand = new DelegateCommand(OnSend);
            ClickedPreviewMainViewCommand = new DelegateCommand(OnPreviewMainView);
            base.RegisterCommand();
        }

        private void OnPreviewMainView()
        {
            PreviewMainView();
        }

        private void OnSend()
        {
        }
    }
}