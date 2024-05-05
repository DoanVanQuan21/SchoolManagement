using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.AccountManagement.ViewModels
{
    public class ChangePasswordViewModel : BaseRegionViewModel
    {
        public override string Title => "Đổi mật khẩu";

        public override User User { get; protected set; }

        public ChangePasswordViewModel()
        {
        }

        public ChangePasswordViewModel(User user)
        {
            User = user;
        }
    }
}