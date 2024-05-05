using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.ClassManagement.ViewModels
{
    internal class ClassManagementViewModel : BaseRegionViewModel
    {
        private Class selectedClass;

        public override string Title => "Quản lý lớp học";

        public override User User { get; protected set; }

        public ClassManagementViewModel()
        {
            User = RootContext.CurrentUser;
            Classes = new();
        }

        public ObservableCollection<Class> Classes { get; set; }
        public Class SelectedClass { get => selectedClass; set => SetProperty(ref selectedClass, value); }
    }
}