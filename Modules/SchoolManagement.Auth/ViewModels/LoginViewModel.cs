using Avalonia.Controls;
using Prism.Commands;
using SchoolManagement.Auth.Views;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Windows.Input;

namespace SchoolManagement.Auth.ViewModels
{
    public class LoginViewModel : BaseRegionViewModel
    {
        private readonly IAppManager _appManager;
        private readonly IUserService _userService;
        private string logoPath;

        public LoginViewModel() : base()
        {
            User = new();
            _userService = Ioc.Resolve<IUserService>();
            _appManager = Ioc.Resolve<IAppManager>();
            LogoPath = "avares://SchoolManagement.UI/Assets/Images/logo/logo.png";
        }

        public ICommand ClickedForgotPasswordCommand { get; set; }
        public ICommand ClickedLoginCommand { get; set; }
        public ICommand ClickedRegisterCommand { get; set; }
        public ContentControl Container { get; set; }

        public string LogoPath
        { get => logoPath; set { SetProperty(ref logoPath, value); } }

        public override string Title => Util.GetResourseString("Login_Label");

        public override User User { get; protected set; }

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

        private async void OnLogin()
        {
            try
            {
                if (User == null)
                {
                    EventAggregator.GetEvent<LoginSuccessEvent>().Publish(false);
                    return;
                }
                if (string.IsNullOrEmpty(User.Username) || string.IsNullOrEmpty(User.Password))
                {
                    NotificationManager.ShowWarning(Util.GetResourseString("InforEmpty_Message"));
                    return;
                }
                var (isLogin, user) = await _userService.Login(User);
                if (user == null)
                {
                    EventAggregator.GetEvent<LoginSuccessEvent>().Publish(false);
                    return;
                }
                RootContext.CurrentUser = user;
                if (user.LockAccount == true)
                {
                    NotificationManager.ShowWarning(Util.GetResourseString("AccountLocked_Message"));
                    return;
                }
                EventAggregator.GetEvent<LoginSuccessEvent>().Publish(isLogin);
            }
            catch (Exception ex)
            {
                NotificationManager.ShowError($"{Util.GetResourseString("DatabaseFailed_Message")}\n{ex.Message}", 5);
            }
        }

        private void OnRegister()
        {
            _appManager.Save();
            SetMainView(new RegisterAccountView());
        }
    }
}