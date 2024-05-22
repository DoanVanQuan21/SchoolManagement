using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Windows.Input;

namespace SchoolManagement.SettingAccount.ViewModels
{
    public class ChangePasswordViewModel : BaseRegionViewModel
    {
        private string confirmPassword;

        public override string Title => Util.GetResourseString("ChangePassword_Label");

        public override User User { get; protected set; }

        public ChangePasswordViewModel()
        {
            User = new();
        }

        public string ConfirmPassword { get => confirmPassword; set => SetProperty(ref confirmPassword, value); }
        public Action<User> ChangePassword { get; set; }
        public ICommand ClickedExit { get; set; }
        public ICommand ClickedOK { get; set; }

        protected override void RegisterCommand()
        {
            ClickedExit = new DelegateCommand(OnExit);
            ClickedOK = new DelegateCommand(OnOK);
            base.RegisterCommand();
        }

        private void OnOK()
        {
            if (User == null)
            {
                return;
            }
            if(string.IsNullOrEmpty(ConfirmPassword) || string.IsNullOrEmpty(User.Password)) {
                NotificationManager.ShowWarning(Util.GetResourseString("ConfirmPasswordEmpty_Message"));
                return;
            }
            if(ConfirmPassword != User.Password)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("PasswordNotEqual_Message"));
                return;
            }
            ChangePassword?.Invoke(User);
        }

        private void OnExit()
        {
            CloseDialog();
        }
    }
}