using Avalonia.Controls;
using Avalonia.Platform.Storage;
using DynamicData;
using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    public class UploadGradeSheetViewModel : BaseRegionViewModel
    {
        private readonly IClassService _classService;
        private readonly IExcelService _excelService;
        private readonly IGradeSheetService _gradeSheetService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;
        private Class @class;
        private ObservableCollection<Class> classes;
        private bool dataLoaded = false;
        private GradeSheet gradeSheet;
        private ObservableCollection<GradeSheet> gradeSheets;
        private bool isUploadFile = false;
        private Student student;
        private ObservableCollection<Student> students;

        public UploadGradeSheetViewModel()
        {
            _excelService = Ioc.Resolve<IExcelService>();
            _studentService = Ioc.Resolve<IStudentService>();
            _classService = Ioc.Resolve<IClassService>();
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            _courseService = Ioc.Resolve<ICourseService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            User = RootContext.CurrentUser;
            GradeSheets = new();
            Class = new Class();
            Classes = new();
            Students = new();
            GradeSheet = new();
        }

        public Class Class
        {
            get => @class; set
            {
                SetProperty(ref @class, value);
                GetStudentsByClassAsync();
            }
        }

        public ObservableCollection<Class> Classes
        { get => classes; set { SetProperty(ref classes, value); } }

        public ICommand ClickedAddSingle { get; set; }
        public ICommand ClickedExit { get; set; }
        public ICommand ClickedOK { get; set; }
        public ICommand ClickedUploadFile { get; set; }

        public bool DataLoaded
        { get => dataLoaded; set { SetProperty(ref dataLoaded, value); } }

        public GradeSheet GradeSheet { get => gradeSheet; set => SetProperty(ref gradeSheet, value); }

        public ObservableCollection<GradeSheet> GradeSheets
        { get => gradeSheets; set { SetProperty(ref gradeSheets, value); } }

        public bool IsUploadFile { get => isUploadFile; set => SetProperty(ref isUploadFile, value); }
        public Student Student { get => student; set => SetProperty(ref student, value); }

        public ObservableCollection<Student> Students
        { get => students; set { SetProperty(ref students, value); } }

        public override string Title => "Upload file";

        public override User User { get; protected set; }

        protected override void RegisterCommand()
        {
            ClickedUploadFile = new DelegateCommand(OnUpload);
            ClickedAddSingle = new DelegateCommand(OnAddSingle);
            ClickedExit = new DelegateCommand(OnExit);
            ClickedOK = new DelegateCommand(OnOK);
            base.RegisterCommand();
        }

        private Task GetFullDetailGradeSheet(ObservableCollection<GradeSheet> gradeSheets)
        {
            return Task.Factory.StartNew(async () =>
            {
                foreach (var gs in gradeSheets)
                {
                    var teacher =await _teacherService.GetTeacherInfoAsync(User.UserId);
                    if (teacher==null)
                    {
                        continue;
                    }
                    gs.Ranked = GradeSheet.GetRanked(gs);
                    gs.Student = _studentService.GetStudent(gs.StudentId);
                    gs.ClassId = Class.ClassId;
                    gs.SubjectId = teacher.SubjectId;
                    gs.Class = Class;
                }
            });
        }

        private async void GetStudentsByClassAsync()
        {
            try
            {
                if (Class == null)
                {
                    return;
                }
                var students = await _studentService.GetStudentsByClass(Class.ClassId);
                if (students == null)
                {
                    NotificationManager.ShowWarning("Không có học sinh nào!.");
                    return;
                }
                Students.Clear();
                Students.AddRange(students);
            }
            catch (Exception e)
            {
                NotificationManager.ShowError(e.Message);
            }
        }

        private void OnAddSingle()
        {
            if (IsUploadFile)
            {
                IsUploadFile = false;
                DataLoaded = false;
            }
        }

        private void OnExit()
        {
            CloseDialog();
        }

        private async void OnOK()
        {
            var isOK = await _gradeSheetService.UpdateOrAddRange(GradeSheets);
            if (isOK)
            {
                NotificationManager.ShowSuccess("Tải bảng điểm thành công!.");
                return;
            }
            NotificationManager.ShowWarning("Tải bảng điểm thất bại!.");
        }

        private async void OnUpload()
        {
            try
            {
                IsUploadFile = true;
                DataLoaded = false;
                var topLevel = TopLevel.GetTopLevel(AppRegion.MainView);
                var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
                {
                    Title = "Open Text File",
                    AllowMultiple = false
                });
                if (files.Count <= 0)
                {
                    //TODO
                    // MULTI LANGUAGE
                    NotificationManager.ShowWarning("Không có file nào được chọn");
                    return;
                }
                var path = files.First().Path.LocalPath;
                var gradeSheets = await _excelService.ImportGradeSheetsAsync(path, Class.ClassId, async (studentCode) =>
                {
                    return await _studentService.GetStudentIDByStudentCodeAsync(studentCode);
                });
                await GetFullDetailGradeSheet(gradeSheets);
                GradeSheets.Clear();
                GradeSheets.AddRange(gradeSheets);
                DataLoaded = true;
            }
            catch (Exception e)
            {
                NotificationManager.ShowWarning(e.Message);
            }
        }
    }
}