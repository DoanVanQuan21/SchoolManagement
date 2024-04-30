using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using SchoolManagement.GradeSheetManagement.Views.Dialogs;
using SchoolManagement.UI.Dialogs;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    internal class GradeSheetManagementViewModel : BaseRegionViewModel
    {
        private readonly IClassService _classService;
        private readonly ICourseService _courseService;
        private readonly IExcelService _excelService;
        private readonly IGradeSheetService _gradeSheetService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IUserService _userService;
        private Class _class;
        private bool dataLoaded = false;
        private GradeSheet gradeSheet;
        private ObservableCollection<GradeSheet> gradeSheets;
        private bool isExportCompleted = false;
        private Teacher? teacher;

        public GradeSheetManagementViewModel()
        {
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            _courseService = Ioc.Resolve<ICourseService>();
            _classService = Ioc.Resolve<IClassService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            _excelService = Ioc.Resolve<IExcelService>();
            _studentService = Ioc.Resolve<IStudentService>();
            _userService = Ioc.Resolve<IUserService>();

            User = RootContext.CurrentUser;
            Class = new();
            GradeSheets = new();
            GetClassIDsOfCourse();
        }

        public Class Class
        {
            get => _class; set
            {
                SetProperty(ref _class, value);
                GetGradeSheet().GetAwaiter();
            }
        }

        public ObservableCollection<Class> Classes { get; set; }
        public ICommand ClickedDownloadFile { get; set; }
        public ICommand ClickedUpdateCommand { get; set; }
        public ICommand ClickedAddGradeSheet { get; set; }

        public bool DataLoaded
        { get => dataLoaded; set { SetProperty(ref dataLoaded, value); } }

        public GradeSheet GradeSheet
        { get => gradeSheet; set { SetProperty(ref gradeSheet, value); } }

        public ObservableCollection<GradeSheet> GradeSheets
        { get => gradeSheets; set { SetProperty(ref gradeSheets, value); } }

        public override string Title => "Quản lý điểm";
        public override User User { get; protected set; }

        protected override void RegisterCommand()
        {
            ClickedUpdateCommand = new DelegateCommand(OnUpdate);
            ClickedAddGradeSheet = new DelegateCommand(OnAddGradeSheet);
            ClickedDownloadFile = new DelegateCommand(OnDownloadFile);
            base.RegisterCommand();
        }

        protected override void SubcribeEvent()
        {
            EventAggregator.GetEvent<UpdateGradeSheetEvent>().Subscribe(OnUpdatedAsync);

            base.SubcribeEvent();
        }

        private void OnUpdatedAsync(GradeSheet sheet)
        {
            var gradesheet = GradeSheets.FirstOrDefault(gs => gs.GradeSheetId == sheet.GradeSheetId);
            gradesheet = sheet;
            gradeSheet.Ranked = GradeSheet.GetRanked(gradeSheet);
        }

        private async Task ExportFile(string filePath)
        {
            isExportCompleted = await _excelService.ExportGradeSheetsAsync(GradeSheets, filePath, Class.ClassName, async (studentID) =>
            {
                return await GetFullName(studentID);
            }, async (studentID) =>
            {
                return await GetStudentCode(studentID);
            });
            CloseDialog();
            if (!isExportCompleted)
            {
                NotificationManager.ShowWarning($"Không thể tải được file điểm của lớp {Class.ClassName}!.");
                return;
            }
            NotificationManager.ShowSuccess($"Tải file điểm của lớp {Class.ClassName} thành công!.");
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
            Class = Classes.First();
        }

        private async Task<string> GetFullName(object? value)
        {
            try
            {
                var student = await _studentService.GetStudentByStudentIDAsync((int)value);
                Debug.WriteLine(student.User?.ToString());
                var fullName = _userService.GetFullname(student.UserId);
                return fullName;
            }
            catch (Exception)
            {
                return "NaN";
            }
        }

        private async Task GetGradeSheet()
        {
            DataLoaded = false;
            if (teacher == null || Class == null)
            {
                return;
            }
            await Task.Delay(1000);
            var grades = await _gradeSheetService.GetGradeSheetsAsync(teacher.SubjectId, Class.ClassId);
            if (grades == null)
            {
                return;
            }
            GradeSheets?.Clear();
            GradeSheets?.AddRange(grades);
            await Task.Delay(1000);
            DataLoaded = true;
        }

        private async Task<string?> GetStudentCode(int studentId)
        {
            try
            {
                var student = await _studentService.GetStudentByStudentIDAsync(studentId);
                Debug.WriteLine(student?.User?.ToString());
                return student?.StudentCode;
            }
            catch (Exception)
            {
                return "NaN";
            }
        }

        private async void OnDownloadFile()
        {
            var topLevel = TopLevel.GetTopLevel(AppRegion.MainView);
            var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions()
            {
                Title = "Save file",
                SuggestedFileName = $"{Class.ClassName}.xlsx",
            });
            if (file == null)
            {
                return;
            }
            var filePath = file.TryGetLocalPath();
            if (string.IsNullOrWhiteSpace(filePath))
                return; // User canceled
            var progressDialog = ShowDialogHost(new ProgressDialog());
            var download = ExportFile(filePath);
            await Task.WhenAll(progressDialog, download);
        }

        private async void OnUpdate()
        {
            var editView = new EditGradeSheetView();
            editView.ViewModel.GradeSheet = new(GradeSheet);
            await ShowDialogHost(editView);
        }

        private async void OnAddGradeSheet()
        {
            var uploadView = new UploadGradeSheets();
            uploadView.GradeSheetViewModel.Classes = Classes;
            await ShowDialogHost(uploadView);
        }
    }
}