﻿using Avalonia.Controls;
using Avalonia.Platform.Storage;
using DynamicData;
using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.Common;
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
        private Semester semester;

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

        public Date CurrentDate
        { get; set; }

        public GradeSheet GradeSheet { get => gradeSheet; set => SetProperty(ref gradeSheet, value); }

        public ObservableCollection<GradeSheet> GradeSheets
        { get => gradeSheets; set { SetProperty(ref gradeSheets, value); } }

        public bool IsUploadFile { get => isUploadFile; set => SetProperty(ref isUploadFile, value); }
        public Student Student { get => student; set => SetProperty(ref student, value); }

        public ObservableCollection<Student> Students
        { get => students; set { SetProperty(ref students, value); } }

        public Semester Semester
        { get; set; }

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

        private async Task<List<GradeSheet>> GetFullDetailGradeSheet(ObservableCollection<GradeSheet> gradeSheets)
        {
            var grades = new List<GradeSheet>();
            foreach (var gs in gradeSheets)
            {
                var teacher = await _teacherService.GetTeacherByUserID(User.UserId);
                if (teacher == null)
                {
                    continue;
                }
                gs.Ranked = GradeSheet.GetRanked(gs);
                var student = await _studentService.GetStudentByStudentID(gs.StudentId);
                if (student == null)
                {
                    continue;
                }
                var studentOK = await ValidateStudent(student.StudentId);
                if (!studentOK)
                {
                    continue;
                }
                var course = await _courseService.GetCourse(teacher.TeacherId, Class.ClassId, CurrentDate.Year, Semester.Value);
                if (course == null)
                {
                    continue;
                }
                gs.Student = student;
                gs.StudentId = student.StudentId;
                gs.CourseId = course.CourseId;
                grades.Add(gs);
            }
            return grades;
        }

        private Task<bool> ValidateStudent(int studentID)
        {
            return Task.Factory.StartNew(() =>
            {
                if (Students?.Any() == false)
                {
                    return false;
                }
                var student = Students.FirstOrDefault(s => s.StudentId == studentID);
                if (student == null)
                {
                    return false;
                }
                return true;
            });
        }

        private async void GetStudentsByClassAsync()
        {
            try
            {
                if (Class == null || CurrentDate == null)
                {
                    return;
                }
                var students = await _studentService.GetStudentOfClassByYear(Class.ClassId, CurrentDate.Year);
                if (students == null)
                {
                    NotificationManager.ShowWarning(Util.GetResourseString("StudentsEmpty_Message"));
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
            bool isOK = true;
            if (!IsUploadFile)
            {
                isOK = await AddSingleAsync();
            }
            else
            {
                await SetStudentIsDefault();
                isOK = await _gradeSheetService.UpdateOrAddRange(GradeSheets);
            }
            if (isOK)
            {
                NotificationManager.ShowSuccess(Util.GetResourseString("LoadGradeSheetSuccess_Message"));
                return;
            }
            NotificationManager.ShowWarning(Util.GetResourseString("LoadGradeSheetError_Message"));
        }

        private async Task<bool> AddSingleAsync()
        {
            var teacher = await _teacherService.GetTeacherByUserID(RootContext.CurrentUser.UserId);
            if (teacher == null)
            {
                return false;
            }
            GradeSheet.StudentId = Student.StudentId;
            var course = await _courseService.GetCourse(teacher.TeacherId, Class.ClassId, CurrentDate.Year, Semester.Value);
            if (course == null)
            {
                return false;
            }
            GradeSheet.CourseId = course.CourseId;
            return await _gradeSheetService.AddGradeSheet(GradeSheet);
        }

        private Task SetStudentIsDefault()
        {
            return Task.Factory.StartNew(() =>
            {
                foreach (var grade in GradeSheets)
                {
                    grade.Student = null;
                }
            });
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
                    NotificationManager.ShowWarning(Util.GetResourseString("NoFileSelected_Message"));
                    return;
                }
                var path = files.First().Path.LocalPath;
                var gradeSheets = await _excelService.ImportGradeSheetsAsync(path, Class.ClassId, async (studentCode) =>
                {
                    return await _studentService.GetStudentByStudentCode(studentCode);
                });
                var gradesFull = await GetFullDetailGradeSheet(gradeSheets);
                GradeSheets.Clear();
                GradeSheets.AddRange(gradesFull);
                DataLoaded = true;
            }
            catch (Exception e)
            {
                NotificationManager.ShowWarning(e.Message);
            }
        }
    }
}