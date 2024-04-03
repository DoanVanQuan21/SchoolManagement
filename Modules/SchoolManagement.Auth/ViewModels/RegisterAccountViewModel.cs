using Prism.Commands;
using SchoolManagement.Core.avalonia;
using System.Windows.Input;

namespace SchoolManagement.Auth.ViewModels
{
    internal class RegisterAccountViewModel : BaseRegionViewModel
    {
        public override string Title => "Register Account";
        public RegisterAccountViewModel()
        {
            
        }
        public ICommand ClickedPreviewMainViewCommand { get; set; }
        protected override void RegisterCommand()
        {
            ClickedPreviewMainViewCommand = new DelegateCommand(OnPreviewMainView);
            base.RegisterCommand();
        }

        private void OnPreviewMainView()
        {
            PreviewMainView();
        }
    }
}