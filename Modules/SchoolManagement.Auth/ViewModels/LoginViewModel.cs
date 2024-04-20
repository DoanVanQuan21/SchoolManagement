﻿using Avalonia.Controls;
using Prism.Commands;
using SchoolManagement.ApiService.Contracts;
using SchoolManagement.Auth.Views;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Models.SchoolManagements;
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

        public override string Title => "Đăng nhập";

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
            if (User == null)
            {
                EventAggregator.GetEvent<LoginSuccessEvent>().Publish(false);
                return;
            }
            var (isLoginOK, user) = await _userService.Login(User.Username, User.Password);
            if (!isLoginOK || user == null)
            {
                EventAggregator.GetEvent<LoginSuccessEvent>().Publish(false);
                return;
            }
            RootContext.CurrentUser = user;
            EventAggregator.GetEvent<LoginSuccessEvent>().Publish(true);
            //var box = MsBox.Avalonia.MessageBoxManager.GetMessageBoxStandard("Notify", "Hello", ButtonEnum.OkCancel);
            //await box.ShowAsPopupAsync(Container);
        }

        private void OnRegister()
        {
            _appManager.Save();
            SetMainView(new RegisterAccountView());
        }
    }
}