using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.Database.ViewModels
{
    internal class SelectionDatabaseViewModel : BaseRegionViewModel
    {
        public override string Title => Util.GetResourseString("SelectionDatabase_Label");

        public override User User { get; protected set; }

        public SelectionDatabaseViewModel()
        {
            //TODO
            User = new();
        }
    }
}