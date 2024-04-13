using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Windows.Input;

namespace SchoolManagement.Auth.ViewModels
{
    internal class RegisterAccountViewModel : BaseRegionViewModel
    {
        public RegisterAccountViewModel() : base()
        {
            User = new User();
        }

        public ICommand ClickedPreviewMainViewCommand { get; set; }
        public ICommand ClickedRegisterAccountCommand { get; set; }
        public override string Title => "Register Account";

        public override User User { get; protected set; }

        protected override void RegisterCommand()
        {
            ClickedPreviewMainViewCommand = new DelegateCommand(OnPreviewMainView);
            ClickedRegisterAccountCommand = new DelegateCommand(OnRegisterAccount);
            base.RegisterCommand();
        }

        private void OnPreviewMainView()
        {
            PreviewMainView();
        }

        private void OnRegisterAccount()
        {
        }
    }
}