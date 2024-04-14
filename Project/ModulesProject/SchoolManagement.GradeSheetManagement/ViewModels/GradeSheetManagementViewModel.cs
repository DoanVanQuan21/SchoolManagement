using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System.Collections.ObjectModel;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    internal class GradeSheetManagementViewModel : BaseRegionViewModel
    {
        private readonly IClassService _classService;
        private readonly ICourseService _courseService;
        private readonly IGradeSheetService _gradeSheetService;
        private readonly ITeacherService _teacherService;
        private Class _class;
        private Teacher? teacher;
        public GradeSheetManagementViewModel()
        {
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            _courseService = Ioc.Resolve<ICourseService>();
            _classService = Ioc.Resolve<IClassService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            User = RootContext.CurrentUser;
            Class = new();
            GradeSheets = new();
            GetClassIDsOfCourse();
        }

        public Class Class
        { get => _class; set { SetProperty(ref _class, value);
                GetGradeSheet();
            } }

        public ObservableCollection<Class> Classes { get; set; }
        public ObservableCollection<GradeSheet> GradeSheets { get; set; }
        public override string Title => "Quản lý điểm";
        public override User User { get; protected set; }
        private void GetGradeSheet()
        {
            if (teacher == null || Class==null)
            {
                return;
            }

            var gradeSheets = _gradeSheetService.GetGradeSheets(teacher.SubjectId,Class.ClassId);
            if(gradeSheets == null)
            {
                return;
            }
            GradeSheets?.Clear();
            GradeSheets?.AddRange(gradeSheets);
        }
        private void GetClassIDsOfCourse()
        {
            Classes = new();
            teacher = _teacherService.GetTeacherInfo(User.UserId);
            if (teacher == null)
            {
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
            Classes.AddRange(classes);
        }
    }
}