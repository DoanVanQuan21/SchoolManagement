using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.CourseManagement.ViewModels
{
    public class AddCourseViewModel : BaseRegionViewModel
    {
        private const int MAX_YEAR = 2;
        private readonly IClassService _classService;
        private readonly IEducationProgramService _educationProgramService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;
        private Class currentClass;
        private Subject currentSubject;

        public AddCourseViewModel()
        {
            _classService = Ioc.Resolve<IClassService>();
            _userService = Ioc.Resolve<IUserService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            _subjectService = Ioc.Resolve<ISubjectService>();
            _educationProgramService = Ioc.Resolve<IEducationProgramService>();
            _courseService = Ioc.Resolve<ICourseService>();
            User = RootContext.CurrentUser;
            Course = new();
            Dates = new();
            Classes = new();
            EducationPrograms = new();
            Subjects = new();
            Teachers = new();
            Init();
        }

        public Action<Course> AddCourseAction { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public ICommand ClickedExit { get; set; }
        public ICommand ClickedOK { get; set; }
        public Course Course { get; set; }

        public Class CurrentClass
        {
            get => currentClass; set
            {
                SetProperty(ref currentClass, value);
                GetSubjects().GetAwaiter();
            }
        }

        public Date CurrentDate { get; set; }
        public EducationProgram CurrentEducationProgram { get; set; }
        public Semester CurrentSemester { get; set; }

        public Subject CurrentSubject
        {
            get => currentSubject; set
            {
                SetProperty(ref currentSubject, value);
                GetTeachers().GetAwaiter();
            }
        }

        public Teacher CurrentTeacher { get; set; }
        public ObservableCollection<Date> Dates { get; set; }
        public ObservableCollection<EducationProgram> EducationPrograms { get; set; }
        public List<Semester> Semesters => Semester.Semesters;
        public ObservableCollection<Subject> Subjects { get; set; }
        public ObservableCollection<Teacher> Teachers { get; set; }
        public override string Title => "Thêm khóa học";

        public override User User { get; protected set; }

        protected override void RegisterCommand()
        {
            ClickedExit = new DelegateCommand(OnExit);
            ClickedOK = new DelegateCommand(OnOK);
        }

        private async Task GetClasses()
        {
            Classes.Clear();
            var classes = await _classService.GetClasses();
            if (classes?.Any() == false)
            {
                return;
            }
            Classes.AddRange(classes);
        }

        private async Task GetTeachers()
        {
            Teachers.Clear();
            if (CurrentSubject == null)
            {
                return;
            }
            var teachers = await _teacherService.GetTeachersBySubjectID(CurrentSubject.SubjectId);
            if (teachers?.Any() == false) { return; }
            Teachers.AddRange(teachers);
        }

        private async Task GetEducationPrograms()
        {
            EducationPrograms.Clear();
            var eds = await _educationProgramService.GetEdicationPrograms(CommonStatus.Active.ToString());
            if (eds?.Any() == false)
            {
                return;
            }
            EducationPrograms.AddRange(eds);
        }

        private async Task GetSubjects()
        {
            Subjects.Clear();
            if (CurrentClass == null || CurrentDate == null || CurrentSemester == null)
            {
                return;
            }
            var subjectIDsOfCourse = await _courseService.GetSubjectIDs(CurrentClass.ClassId, CurrentDate.Year, CurrentSemester.Value);
            var subjects = await _subjectService.GetSubjects();
            if (subjects?.Any() == false)
            {
                return;
            }
            foreach (var sb in subjects)
            {
                var subject = subjectIDsOfCourse.FirstOrDefault(s => s == sb.SubjectId);
                if (subject != 0)
                {
                    continue;
                }
                Subjects.Add(sb);
            }
        }

        private Task InitDates()
        {
            return Task.Factory.StartNew(() =>
            {
                Dates.Clear();
                var year = DateTime.Now.Year;
                for (int i = 0; i < MAX_YEAR; i++)
                {
                    Dates.Add(new Date()
                    {
                        Year = year + i,
                    });
                }
            });
        }

        private async void Init()
        {
            await InitDates();
            await GetClasses();
            await GetEducationPrograms();
        }

        private void OnExit()
        {
            CloseDialog();
        }

        private void OnOK()
        {
            if (CurrentDate == null || CurrentSemester == null || CurrentClass == null || CurrentSubject == null || CurrentTeacher == null || CurrentEducationProgram == null)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("InvalidInfor_Message"));
                return;
            }
            Course.ClassId = CurrentClass.ClassId;
            Course.SubjectId = CurrentSubject.SubjectId;
            Course.TeacherId = CurrentTeacher.TeacherId;
            Course.EducationProgramId = CurrentEducationProgram.EducationProgramId;
            Course.Semester = CurrentSemester.Value;
            Course.Status = "Đang học";
            AddCourseAction?.Invoke(Course);
        }
    }
}