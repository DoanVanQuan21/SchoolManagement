using Prism.Commands;
using SchoolManagement.Core.avalonia;
using System.Windows.Input;

namespace SchoolManagement.Auth.ViewModels
{
    internal class RegisterAccountViewModel : BaseRegionViewModel
    {
        public override string Title => "Register Account";

        public RegisterAccountViewModel() : base()
        {
        }

        public ICommand ClickedPreviewMainViewCommand { get; set; }
        public ICommand ClickedRegisterAccountCommand { get; set; }

        protected override void RegisterCommand()
        {
            ClickedPreviewMainViewCommand = new DelegateCommand(OnPreviewMainView);
            ClickedRegisterAccountCommand = new DelegateCommand(OnRegisterAccount);
            base.RegisterCommand();
        }

        private void OnRegisterAccount()
        {
        }

        private void OnPreviewMainView()
        {
            PreviewMainView();
        }
    }
}