using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.Database.ViewModels
{
    internal class SelectionDatabaseViewModel : BaseRegionViewModel
    {
        public override string Title => "Chọn cơ sở dữ liệu";

        public override User User { get; protected set; }

        public SelectionDatabaseViewModel()
        {
            //TODO
            User = new();
        }
    }
}