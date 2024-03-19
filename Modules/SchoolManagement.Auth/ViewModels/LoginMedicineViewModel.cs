using SchoolManagement.Auth.Contracts;
using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models;

namespace SchoolManagement.Auth.ViewModels
{
    public class LoginMedicineViewModel : BaseRegionViewModel
    {
        private readonly ILoginService _loginService;
        public User User { get; set; }
        public override string Title => "Đăng nhập";

        public LoginMedicineViewModel() : base()
        {
            _loginService = Ioc.Resolve<ILoginService>();
            User = new();
        }

        protected override void RegisterCommand()
        {
            LoginCommand = new DelegateCommand(OnLogin);
        }

        private void OnLogin()
        {
            if (User == null)
            {
                return;
            }
        }

        protected override void RegisterEvent()
        {
        }
    }
}