using Prism.Commands;
using SchoolManagement.ApiService.Contracts;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Windows.Input;

namespace SchoolManagement.SettingAccount.ViewModels
{
    internal class SettingAccountViewModel : BaseRegionViewModel
    {
        private readonly IUserService _userService;
        private User user;

        public SettingAccountViewModel()
        {
            _userService = Ioc.Resolve<IUserService>();
            User = new User(RootContext.CurrentUser);
        }

        public ICommand ClickedUpdateInformation { get; set; }
        public override string Title => "Setting Account";

        public override User User
        { get => user; protected set { SetProperty(ref user, value); } }

        protected override void RegisterCommand()
        {
            ClickedUpdateInformation = new DelegateCommand(OnUpdateInfo);
            base.RegisterCommand();
        }

        private void OnUpdateInfo()
        {
            //var isUpdated = _userService.UpdateUserInfor(User);
            //if (!isUpdated)
            //{
            //    NotificationManager.ShowSuccess(Util.GetResourseString("UpdateUserFail_Message"));
            //    return;
            //}
            //UpdateCurrentUser(User);
            //NotificationManager.ShowSuccess(Util.GetResourseString("UpdateUserSuccess_Message"));
        }
    }
}