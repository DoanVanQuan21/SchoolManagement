using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagement;

namespace SchoolManagement.Auth.ViewModels
{
    public class LoginMedicineViewModel : BaseRegionViewModel
    {
        public User User { get; set; }
        public override string Title => "Đăng nhập";

        public LoginMedicineViewModel() : base()
        {
            User = new();
        }

        private void OnLogin()
        {
            if (User == null)
            {
                return;
            }
        }
    }
}