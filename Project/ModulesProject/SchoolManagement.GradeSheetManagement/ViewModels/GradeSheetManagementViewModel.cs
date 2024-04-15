using Prism.Commands;
using Prism.Services.Dialogs;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using SchoolManagement.GradeSheetManagement.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
        private ObservableCollection<GradeSheet> gradeSheets;
        private GradeSheet gradeSheet;

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

        public ICommand ClickedUpdateCommand { get; set; }

        public Class Class
        {
            get => _class; set
            {
                SetProperty(ref _class, value);
                GetGradeSheet();
            }
        }

        public ObservableCollection<Class> Classes { get; set; }

        public ObservableCollection<GradeSheet> GradeSheets
        { get => gradeSheets; set { SetProperty(ref gradeSheets, value); } }

        public GradeSheet GradeSheet
        { get => gradeSheet; set { SetProperty(ref gradeSheet, value); } }
        public override string Title => "Quản lý điểm";
        public override User User { get; protected set; }

        private async void GetGradeSheet()
        {
            if (teacher == null || Class == null)
            {
                return;
            }

            var gradeSheets = await _gradeSheetService.GetGradeSheetsAsync(teacher.SubjectId, Class.ClassId);
            if (gradeSheets == null)
            {
                return;
            }
            GradeSheets?.Clear();
            GradeSheets?.AddRange(gradeSheets);
        }

        private async void GetClassIDsOfCourse()
        {
            Classes = new();
            teacher = await _teacherService.GetTeacherInfoAsync(User.UserId);
            if (teacher == null)
            {
                //TODO
                //ADD MESSAGE
                return;
            }
            var classIDs = await _courseService.GetClassIDsAsync(teacher.TeacherId);
            var classes = await _classService.GetAllClassesByIDAsync(classIDs);
            if (classes == null)
            {
                //TODO
                //ADD MESSAGE
                return;
            }
            Classes.AddRange(classes);
        }

        protected override void RegisterCommand()
        {
            ClickedUpdateCommand = new DelegateCommand(OnUpdate);
            base.RegisterCommand();
        }

        private void OnUpdate()
        {
            var parmeters = new DialogParameters();
            parmeters.Add("GradeSheet", GradeSheet);
            DialogService.ShowDialog(nameof(EditGradeSheetView), parmeters);
        }
    }
}