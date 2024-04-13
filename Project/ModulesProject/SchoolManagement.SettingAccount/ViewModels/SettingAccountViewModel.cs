using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.SettingAccount.ViewModels
{
    internal class SettingAccountViewModel : BaseRegionViewModel
    {
        private User user;

        public SettingAccountViewModel()
        {
        }

        public override string Title => "Setting Account";

        public override User User
        { get => RootContext.CurrentUser; protected set { SetProperty(ref user, value); } }
    }
}