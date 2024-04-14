using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System.Collections.ObjectModel;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    internal class GradeSheetManagementViewModel : BaseRegionViewModel
    {
        public override string Title => "Quản lý điểm";
        private readonly IGradeSheetService _gradeSheetService;
        private readonly ICourseService _courseService;
        public override User User { get; protected set; }
        public ObservableCollection<GradeSheet> GradeSheets { get; set; }
        public ObservableCollection<Course> Courses { get; set; }

        public GradeSheetManagementViewModel()
        {
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            _courseService = Ioc.Resolve<ICourseService>();
            User = RootContext.CurrentUser;
            GradeSheets = new ObservableCollection<GradeSheet>();
        }
    }
}