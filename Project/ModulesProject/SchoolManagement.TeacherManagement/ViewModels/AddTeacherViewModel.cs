using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.TeacherManagement.ViewModels
{
    public class AddTeacherViewModel : BaseRegionViewModel
    {
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;
        private readonly IDepartmentService _departmentService;
        private readonly ISubjectService _subjectService;
        private Teacher teacher;
        private User currentUser;
        private Department currentDepartment;
        private Subject currentSubject;

        public AddTeacherViewModel()
        {
            _userService = Ioc.Resolve<IUserService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            _departmentService = Ioc.Resolve<IDepartmentService>();
            _subjectService = Ioc.Resolve<ISubjectService>();
            User = RootContext.CurrentUser;
            Users = new();
            Departments = new();
            Subjects = new();
            Teacher = new();
            Init().GetAwaiter();
        }

        private async Task Init()
        {
            await GetAccountOfTeachers();
            await GetDepartments();
            await GetSubjects();
        }

        public override string Title => Util.GetResourseString("AddTeacher_Label");

        public override User User { get; protected set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }
        public User CurrentUser { get => currentUser; set => SetProperty(ref currentUser, value); }
        public Department CurrentDepartment { get => currentDepartment; set => SetProperty(ref currentDepartment, value); }
        public Subject CurrentSubject { get => currentSubject; set => SetProperty(ref currentSubject, value); }
        public Action<Teacher, User, Department, Subject> AddTeacherAction { get; set; }
        public ICommand ClickedExit { get; set; }
        public ICommand ClickedOK { get; set; }
        public Teacher Teacher { get => teacher; set => SetProperty(ref teacher, value); }

        protected override void RegisterCommand()
        {
            ClickedExit = new DelegateCommand(OnExit);
            ClickedOK = new DelegateCommand(OnOK);
            base.RegisterCommand();
        }

        private void OnExit()
        {
            CloseDialog();
        }

        private void OnOK()
        {
            AddTeacherAction?.Invoke(Teacher, CurrentUser, CurrentDepartment, CurrentSubject);
        }

        private async Task GetAccountOfTeachers()
        {
            var accounts = await _userService.GetAccountOfTeachers();
            Users.Clear();
            foreach (var account in accounts)
            {
                var teacher = await _teacherService.GetTeacherByUserID(account.UserId);
                if (teacher != null)
                {
                    continue;
                }
                Users.Add(account);
            }
        }

        private async Task GetDepartments()
        {
            var departments = await _departmentService.GetDepartments();
            Departments.Clear();
            if (departments?.Any() == false)
            {
                return;
            }
            Departments.AddRange(departments);
        }

        private async Task GetSubjects()
        {
            var subjects = await _subjectService.GetSubjects();
            Subjects.Clear();
            if (subjects?.Any() == false)
            {
                return;
            }
            Subjects.AddRange(subjects);
        }
    }
}