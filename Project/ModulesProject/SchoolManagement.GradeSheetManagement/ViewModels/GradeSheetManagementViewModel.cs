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
        private readonly IClassService _classService;
        private readonly ITeacherService _teacherService;
        public override User User { get; protected set; }
        public ObservableCollection<GradeSheet> GradeSheets { get; set; }
        public ObservableCollection<Course> Courses { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public GradeSheetManagementViewModel()
        {
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            _courseService = Ioc.Resolve<ICourseService>();
            _classService = Ioc.Resolve<IClassService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            User = RootContext.CurrentUser;
            GradeSheets = new();
            Courses = new();
            GetClassIDsOfCourse();
        }
        private void GetClassIDsOfCourse()
        {
            var teacher = _teacherService.GetTeacherInfo(User.UserId);
            if(teacher == null) {
                //TODO
                //ADD MESSAGE
                return;
            }
            var classIDs = _courseService.GetClassIDs(teacher.TeacherId);
            var classes = _classService.GetAllClassesByID(classIDs);
            if (classes == null)
            {
                //TODO
                //ADD MESSAGE
                return;
            }
            Classes = new();
            Classes.AddRange(classes);
        }
    }
}