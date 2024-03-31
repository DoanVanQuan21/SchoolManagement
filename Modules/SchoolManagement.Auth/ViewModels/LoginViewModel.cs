using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Managers;
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

        protected override void RegisterCommand()
        {
            ClickedLoginCommand = new DelegateCommand(OnLogin);
            base.RegisterCommand();
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