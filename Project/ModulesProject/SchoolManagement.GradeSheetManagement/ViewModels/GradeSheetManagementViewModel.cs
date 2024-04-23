using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
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
        private readonly ITeacherService _teacherService;
        private Class _class;
        private bool dataLoaded = false;
        private GradeSheet gradeSheet;
        private ObservableCollection<GradeSheet> gradeSheets;
        private Teacher? teacher;
        private bool isExportCompleted = false;

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

        public Class Class
        {
            get => _class; set
            {
                SetProperty(ref _class, value);
                GetGradeSheet();
            }
        }

        public ObservableCollection<Class> Classes { get; set; }
        public ICommand ClickedDownloadFile { get; set; }
        public ICommand ClickedUpdateCommand { get; set; }
        public ICommand ClickedUploadFile { get; set; }

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
            ClickedUploadFile = new DelegateCommand(OnUploadFile);
            ClickedDownloadFile = new DelegateCommand(OnDownloadFile);
            base.RegisterCommand();
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

        private Task<string?> GetStudentCode(int studentId)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    var studentService = Ioc.Resolve<IStudentService>();
                    var student = studentService.GetStudent(studentId);
                    Debug.WriteLine(student?.User?.ToString());
                    return student?.StudentCode;
                }
                catch (Exception)
                {
                    return "NaN";
                }
            });
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
            ShowDialogHostAndClose(new ProcessView(), isExportCompleted);
            isExportCompleted = await _excelService.ExportGradeSheetAsync(GradeSheets, filePath, Class.ClassName, async (studentID) =>
            {
                return await GetFullName(studentID);
            }, async (studentID) =>
            {
                return await GetStudentCode(studentID);
            });
            if (!isExportCompleted)
            {
                NotificationManager.ShowWarning($"Không thể tải được file điểm của lớp {Class.ClassName}!.");
                return;
            }
            NotificationManager.ShowSuccess($"Tải file điểm của lớp {Class.ClassName} thành công!.");
        }

        private void OnUpdate()
        {
            //TODO
            //var parmeters = new DialogParameters();
            //parmeters.Add("GradeSheet", GradeSheet);
            //DialogService.ShowDialog(nameof(EditGradeSheetView), parmeters);
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
    }
}