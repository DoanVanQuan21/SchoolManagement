using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.Core.Services;
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
        private readonly IExcelService _excelService;
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        private readonly IGradeSheetService _gradeSheetService;
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;
        private readonly IEditGradeSheetFormService _editGradeSheetFormService;
        private Class _class;
        private Date currentDate;
        private bool dataLoaded = false;
        private GradeSheet gradeSheet;
        private ObservableCollection<GradeSheet> gradeSheets;
        private bool isExportCompleted = false;
        private Teacher? teacher;
        private Semester semester;

        public GradeSheetManagementViewModel()
        {
            _excelService = Ioc.Resolve<IExcelService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            _courseService = Ioc.Resolve<ICourseService>();
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            _studentService = Ioc.Resolve<IStudentService>();
            _userService = Ioc.Resolve<IUserService>();
            _editGradeSheetFormService = Ioc.Resolve<IEditGradeSheetFormService>();
            User = RootContext.CurrentUser;
            Class = new();
            Classes = new();
            GradeSheets = new();
            Dates = new();
            InitDates();
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
        public ICommand ClickedAddGradeSheet { get; set; }
        public ICommand ClickedDownloadFile { get; set; }
        public ICommand ClickedFinishCommand { get; set; }
        public ICommand ClickedSendRequestEditCommand { get; set; }
        public ICommand ClickedUpdateCommand { get; set; }
        public List<Semester> Semesters => Semester.Semesters;

        public Date CurrentDate
        { get => currentDate; set { SetProperty(ref currentDate, value); } }

        public Semester Semester
        { get => semester; set { SetProperty(ref semester, value); GetClassByDate(); } }

        public bool DataLoaded
        { get => dataLoaded; set { SetProperty(ref dataLoaded, value); } }

        public ObservableCollection<Date> Dates { get; set; }

        public GradeSheet GradeSheet
        { get => gradeSheet; set { SetProperty(ref gradeSheet, value); } }

        public ObservableCollection<GradeSheet> GradeSheets
        { get => gradeSheets; set { SetProperty(ref gradeSheets, value); } }

        public override string Title => Util.GetResourseString("GradeManagement_Label");
        public override User User { get; protected set; }

        protected override void RegisterCommand()
        {
            ClickedUpdateCommand = new DelegateCommand(OnUpdate);
            ClickedAddGradeSheet = new DelegateCommand(OnAddGradeSheet);
            ClickedDownloadFile = new DelegateCommand(OnDownloadFile);
            ClickedFinishCommand = new DelegateCommand(OnFinish);
            ClickedSendRequestEditCommand = new DelegateCommand(OnSend);
            base.RegisterCommand();
        }

        protected override void SubcribeEvent()
        {
            EventAggregator.GetEvent<UpdateGradeSheetEvent>().Subscribe(OnUpdatedAsync);

            base.SubcribeEvent();
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
                NotificationManager.ShowWarning(string.Format(Util.GetResourseString("LoadGradeFileError_Message"), Class.ClassName));
                return;
            }
            NotificationManager.ShowSuccess(string.Format(Util.GetResourseString("LoadGradeFileSuccess_Message"), Class.ClassName));
        }

        private async void GetClassByDate()
        {
            Classes.Clear();
            GradeSheets.Clear();
            Semester ??= new();
            teacher = await _teacherService.GetTeacherByUserID(User.UserId);
            if (teacher == null || CurrentDate == null || Semester == null)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("InvalidInfor_Message"));
                return;
            }
            var courses = await _courseService.GetCourseOfTeacherByYear(teacher.TeacherId, CurrentDate.Year, Semester.Value);
            if (courses?.Any() == false)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("ClassroomsEmpty_Message"));
                Class = new();
                return;
            }
            var classes = courses.Select(c => c.Class);
            if (classes?.Any() == false)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("ClassroomsEmpty_Message"));
                Class = new();

                return;
            }
            Classes.AddRange(classes);
        }

        private async Task<string> GetFullName(object? value)
        {
            try
            {
                var student = await _studentService.GetStudentByStudentID((int)value);
                Debug.WriteLine(student.User?.ToString());
                var fullName = await _userService.GetFullname(student.UserId);
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
            GradeSheets?.Clear();

            var courses = await _courseService.GetCourses(teacher.TeacherId, teacher.SubjectId, Class.ClassId, CurrentDate.Year);
            foreach (var course in courses)
            {
                var grade = await _gradeSheetService.GetGradeSheetOfSubjectByClass(course.CourseId);
                if (grade == null)
                {
                    continue;
                }
                GradeSheets?.AddRange(grade);
                await Task.Delay(10);
            }
            DataLoaded = true;
        }

        private async Task<string?> GetStudentCode(int studentId)
        {
            try
            {
                var student = await _studentService.GetStudentByStudentID(studentId);
                Debug.WriteLine(student?.User?.ToString());
                return student?.StudentCode;
            }
            catch (Exception)
            {
                return "NaN";
            }
        }

        private async void InitDates()
        {
            Dates = new();
            var startYear = User.StartDate.Year;
            var now = DateTime.Now.Year;
            for (int i = startYear; i <= now; i++)
            {
                Dates.Add(new Date()
                {
                    Year = i,
                });
                await Task.Delay(100);
            }
        }

        private async void OnAddGradeSheet()
        {
            var uploadView = new UploadGradeSheets();
            uploadView.GradeSheetViewModel.Classes = Classes;
            uploadView.GradeSheetViewModel.Semester = Semester;
            uploadView.GradeSheetViewModel.CurrentDate = CurrentDate;

            await ShowDialogHost(uploadView);
        }

        private async void OnDownloadFile()
        {
            if (Class == null)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("NoClassroomSelected_Message"));
                return;
            }
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

        private async void OnFinish()
        {
            var missingGrades = await _gradeSheetService.FinishEditGradeSheet(GradeSheets);
            if (missingGrades?.Count <= 0)
            {
                NotificationManager.ShowSuccess(Util.GetResourseString("UpdateSuccess_Message"));
                return;
            }
            NotificationManager.ShowWarning(string.Format(Util.GetResourseString("UpdateGradeSheetError_Message"), string.Join(',', missingGrades.Select(g => g.Student?.User?.FullName))));
        }

        private async void OnSend()
        {
            var teacher = await _teacherService.GetTeacherByUserID(User.UserId);
            if (teacher == null)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("DatabaseFailed_Message"));
                return;
            }
            var form = new EditGradeSheetForm()
            {
                Status = AceptFormStatus.Waitting.ToString(),
                GradeSheetId = GradeSheet.GradeSheetId,
                TeacherId = teacher.TeacherId,
            };
            var requestView = new RequestEditGradeSheetView();
            requestView.ViewModel.EditGradeSheetForm = form;
            requestView.SetSendRequestEvent(SendRequest);
            await ShowDialogHost(requestView);
        }

        private async void SendRequest(EditGradeSheetForm form)
        {
            form.Time = DateTime.Now;
            var addOK = await _editGradeSheetFormService.AddForm(form);
            CloseDialog();
            if (addOK)
            {
                NotificationManager.ShowSuccess(Util.GetResourseString("RequestEditGradeSheetSuccess_Message"));
                return;
            }
            NotificationManager.ShowWarning(Util.GetResourseString("RequestEditGradeSheetError_Message"));
        }

        private async void OnUpdate()
        {
            var editView = new EditGradeSheetView();
            editView.ViewModel.GradeSheet = new(GradeSheet);
            await ShowDialogHost(editView);
        }

        private void OnUpdatedAsync(GradeSheet sheet)
        {
            var gradesheet = GradeSheets.FirstOrDefault(gs => gs.GradeSheetId == sheet.GradeSheetId);
            gradesheet = sheet;
            gradeSheet.Ranked = GradeSheet.GetRanked(gradeSheet);
        }
    }
}