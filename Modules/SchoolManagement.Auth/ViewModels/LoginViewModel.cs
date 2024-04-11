using ActiproSoftware.UI.Avalonia.Controls;
using Avalonia.Controls;
using Avalonia.Styling;
using Prism.Commands;
using SchoolManagement.Auth.Views;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Models;
using SchoolManagement.EntityFramework.Contracts;
using System.Windows.Input;

namespace SchoolManagement.Auth.ViewModels
{
    public class LoginViewModel : BaseRegionViewModel
    {
        private readonly IUserService _userService;
        private readonly IAppManager _appManager;
        private string logoPath;
        public ContentControl Container { get; set; }
        public override string Title => "Đăng nhập";

        public LoginViewModel() : base()
        {
            _userService = Ioc.Resolve<IUserService>();
            _appManager = Ioc.Resolve<IAppManager>();
            LogoPath = "avares://SchoolManagement.UI/Assets/Images/logo/logo.png";
        }

        public string LogoPath
        { get => logoPath; set { SetProperty(ref logoPath, value); } }

        public ICommand ClickedLoginCommand { get; set; }
        public ICommand ClickedRegisterCommand { get; set; }
        public ICommand ClickedForgotPasswordCommand { get; set; }

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
            _appManager.Save();
            SetMainView(new RegisterAccountView());
        }

        private void OnLogin()

        {
            if (User == null)
            {
                EventAggregator.GetEvent<LoginSuccessEvent>().Publish(false);
                return;
            }
            var (isLogin, user) = _userService.Login(User);
            if (user != null)
            {
                RootContext.CurrentUser = user;
            }
            //var box = MessageBoxManager.GetMessageBoxStandard("Notify", "Hello", ButtonEnum.OkCancel);
            //await box.ShowAsPopupAsync(Container);
            EventAggregator.GetEvent<LoginSuccessEvent>().Publish(isLogin);
        }
    }
}