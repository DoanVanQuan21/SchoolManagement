using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Prism.Commands;
using Prism.Services.Dialogs;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using SchoolManagement.GradeSheetManagement.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    internal class GradeSheetManagementViewModel : BaseRegionViewModel
    {
        private readonly IClassService _classService;
        private readonly ICourseService _courseService;
        private readonly IGradeSheetService _gradeSheetService;
        private readonly ITeacherService _teacherService;
        private readonly IExcelService _excelService;
        private Class _class;
        private Teacher? teacher;
        private ObservableCollection<GradeSheet> gradeSheets;
        private GradeSheet gradeSheet;
        private bool dataLoaded = false;

        public GradeSheetManagementViewModel()
        {
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            _courseService = Ioc.Resolve<ICourseService>();
            _classService = Ioc.Resolve<IClassService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            _excelService = Ioc.Resolve<IExcelService>();
            User = RootContext.CurrentUser;
            Class = new();
            GradeSheets = new();
            GetClassIDsOfCourse();
        }

        public ICommand ClickedUpdateCommand { get; set; }
        public ICommand ClickedUploadFile { get; set; }
        public ICommand ClickedDownloadFile { get; set; }

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

        public bool DataLoaded
        { get => dataLoaded; set { SetProperty(ref dataLoaded, value); } }

        private async void GetGradeSheet()
        {
            DataLoaded = false;
            if (teacher == null || Class == null)
            {
                return;
            }
            var gradeSheets = await _gradeSheetService.GetGradeSheetsAsync(teacher.SubjectId, Class.ClassId);
            await Task.Delay(2000);
            if (gradeSheets == null)
            {
                return;
            }
            GradeSheets?.Clear();
            GradeSheets?.AddRange(gradeSheets);
            DataLoaded = true;
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
            ClickedUploadFile = new DelegateCommand(OnUploadFile);
            ClickedDownloadFile = new DelegateCommand(OnDownloadFile);
            base.RegisterCommand();
        }

        private async void OnDownloadFile()
        {
            var filePath = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExtension = "xlsx";
            saveDialog.Filters.Add(new FileDialogFilter() { Name = "Excel Files", Extensions = { "xlsx" } });
            filePath = await saveDialog.ShowAsync(new Window());
            if (string.IsNullOrWhiteSpace(filePath))
                return; // User canceled

            await _excelService.ExportGradeSheetAsync(GradeSheets, filePath,Class.ClassName, async (t) =>
            {
                return await GetFullName(t);
            });
        }
        private Task<string> GetFullName(object? value)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    var studentService = Ioc.Resolve<IStudentService>();
                    var userService = Ioc.Resolve<IUserService>();
                    var student = studentService.GetStudent((int)value);
                    Debug.WriteLine(student.User?.ToString());
                    var fullName = userService.GetFullname(student.UserId);
                    return fullName;
                }
                catch (Exception)
                {
                    return "NaN";
                }
            });
        }
        private async void OnUploadFile()
        {
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
            await using var stream = await files[0].OpenReadAsync();
            using var streamReader = new StreamReader(stream);
            var fileContent = await streamReader.ReadToEndAsync();
        }

        private void OnUpdate()
        {
            var parmeters = new DialogParameters();
            parmeters.Add("GradeSheet", GradeSheet);
            DialogService.ShowDialog(nameof(EditGradeSheetView), parmeters);
        }
    }
}