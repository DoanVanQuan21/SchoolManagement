using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.CourseManagement.Views.Dialogs;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.CourseManagement.ViewModels
{
    internal class CourseManagementViewModel : BaseRegionViewModel
    {
        private const int MAX_YEAR = 20;
        private const int MIN_YEAR = 2;
        private readonly IClassService _classService;
        private readonly ICourseService _courseService;
        private readonly IEducationProgramService _educationProgramService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private Class currentClass;
        private Date currentDate;
        private Semester currentSemester;
        private bool dataLoaded = false;
        private Course selectedCourse;

        public CourseManagementViewModel()
        {
            _courseService = Ioc.Resolve<ICourseService>();
            _classService = Ioc.Resolve<IClassService>();
            _subjectService = Ioc.Resolve<ISubjectService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            _educationProgramService = Ioc.Resolve<IEducationProgramService>();
            User = RootContext.CurrentUser;
            Coureses = new();
            Dates = new();
            Classes = new();
            Init();
        }

        public ObservableCollection<Class> Classes { get; set; }
        public ICommand ClickedUpdateCommand { get; set; }
        public ICommand ClickedAddCommand { get; set; }
        public ObservableCollection<Course> Coureses { get; set; }
        public Class CurrentClass { get => currentClass; set => SetProperty(ref currentClass, value); }
        public Date CurrentDate { get => currentDate; set => SetProperty(ref currentDate, value); }

        public Semester CurrentSemester
        { get => currentSemester; set { SetProperty(ref currentSemester, value); GetCourses(); } }

        public bool DataLoaded { get => dataLoaded; set => SetProperty(ref dataLoaded, value); }
        public ObservableCollection<Date> Dates { get; set; }
        public Course SelectedCourse { get => selectedCourse; set => SetProperty(ref selectedCourse, value); }
        public List<Semester> Semesters => Semester.Semesters;
        public override string Title => "Quản lý khóa học";

        public override User User { get; protected set; }

        protected override void RegisterCommand()
        {
            ClickedUpdateCommand = new DelegateCommand(OnUpdate);
            ClickedAddCommand = new DelegateCommand(OnAdd);
            base.RegisterCommand();
        }

        private async void OnAdd()
        {
            var addCourseView = new AddCourseView();
            addCourseView.SetAddCourseEvent(AddCourse);
            await ShowDialogHost(addCourseView);
        }

        private async void AddCourse(Course course)
        {
            if (course == null)
            {
                NotificationManager.ShowError("Có lỗi xảy ra!.");
                return;
            }
            var isAdded = await _courseService.AddCourse(course);
            if (!isAdded)
            {
                NotificationManager.ShowWarning("Thêm khóa học thất bại!.");
                return;
            }
            CloseDialog();
            NotificationManager.ShowWarning("Thêm khóa học thành công!.");
            return;
        }

        private async Task GetClasses()
        {
            var classes = await _classService.GetClasses();
            Classes.Clear();
            if (classes == null)
            {
                return;
            }
            Classes.AddRange(classes);
        }

        private async void GetCourses()
        {
            if (CurrentDate == null || CurrentClass == null || CurrentSemester == null)
            {
                NotificationManager.ShowWarning("Bạn chưa chọn năm học hoặc lớp học!.");
                return;
            }
            DataLoaded = false;
            Coureses.Clear();
            var courses = await _courseService.GetCourses(CurrentDate.Year, CurrentSemester.Value, CurrentClass.ClassId);
            if (courses?.Any() == false)
            {
                NotificationManager.ShowWarning("Không có khóa học nào!.");
                return;
            }
            foreach (var course in courses)
            {
                course.Subject = await _subjectService.GetSubject(course.SubjectId);
                course.Class = await _classService.GetClassByID(course.ClassId);
                course.Teacher = await _teacherService.GetTeacherByTeacherID(course.TeacherId);
                course.EducationProgram = await _educationProgramService.GetEducationProgram(course.EducationProgramId);
            }
            Coureses.AddRange(courses);
            DataLoaded = true;
        }

        private async void Init()
        {
            await InitDates();
            await GetClasses();
        }

        private async Task InitDates()
        {
            var year = DateTime.Now.Year;
            var startYear = year - MAX_YEAR;
            var endYear = year + MIN_YEAR;
            await DateHelper.InitDates(startYear, endYear, Dates);
        }

        private void OnUpdate()
        {
        }
    }
}