using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.MainProject.ViewModels
{
    internal class DashboardViewModel : BaseRegionViewModel
    {
        public DashboardViewModel()
        {
            User = new User();
        }

        public override string Title => "Trang chủ";

        public override User User { get; protected set; }
    }
}