using Prism.Commands;
using SchoolManagement.Auth.Views;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Models.SchoolManagement;
using System.Windows.Input;

namespace SchoolManagement.Auth.ViewModels
{
    public class LoginViewModel : BaseRegionViewModel
    {
        private string logoPath;

        public User User { get; set; }
        public override string Title => "Đăng nhập";

        public LoginViewModel() : base()
        {
            User = new();
            LogoPath = "avares://SchoolManagement.UI/Assets/Images/logo/logo.png";
        }

        public string LogoPath
        { get => logoPath; set { SetProperty(ref logoPath, value); } }

        public ICommand ClickedLoginCommand { get; set; }
        public ICommand ClickedRegisterCommand { get; set; }
        public ICommand ClickedForgotPasswordCommand{get;set;}
        protected override void RegisterCommand()
        {
            ClickedLoginCommand = new DelegateCommand(OnLogin);
            ClickedRegisterCommand = new DelegateCommand(OnRegister);
            ClickedForgotPasswordCommand = new DelegateCommand(OnForgotPassword);
            base.RegisterCommand();
        }

        private void OnForgotPassword()
        {
            SetMainView(new ForgotPasswordView());
        }

        private void OnRegister()
        {
            SetMainView(new RegisterAccountView());
        }

        private void OnLogin()
        {
            if (User == null)
            {
                return;
            }
            EventAggregator.GetEvent<LoginSuccessEvent>().Publish();
        }
    }
}