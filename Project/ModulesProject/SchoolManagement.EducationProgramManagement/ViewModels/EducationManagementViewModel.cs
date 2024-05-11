using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EducationProgramManagement.ViewModels
{
    internal class EducationManagementViewModel : BaseRegionViewModel
    {
        private EducationProgram selectedEducationProgram;

        public override string Title => "Quản lý chương trình học";

        public override User User { get; protected set; }

        public EducationManagementViewModel()
        {
            User = RootContext.CurrentUser;
        }

        public ObservableCollection<EducationProgram> Coureses { get; set; }
        public EducationProgram SelectedEducationProgram { get => selectedEducationProgram; set => SetProperty(ref selectedEducationProgram, value); }
    }
}