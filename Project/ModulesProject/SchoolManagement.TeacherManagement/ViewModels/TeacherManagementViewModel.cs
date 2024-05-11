using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using SchoolManagement.TeacherManagement.Views.Dialogs;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.TeacherManagement.ViewModels
{
    internal class TeacherManagementViewModel : BaseRegionViewModel
    {
        private readonly ITeacherService _teacherService;
        private readonly IUserService _userService;
        private bool dataLoaded = false;

        public TeacherManagementViewModel()
        {
            _teacherService = Ioc.Resolve<ITeacherService>();
            _userService = Ioc.Resolve<IUserService>();
            User = RootContext.CurrentUser;
            Teachers = new();
            GetTeachers().GetAwaiter();
        }

        public ICommand ClickedAddCommand { get; set; }
        public ICommand ClickedNextCommand { get; set; }
        public ICommand ClickedPreviousCommand { get; set; }
        public bool DataLoaded { get => dataLoaded; set => SetProperty(ref dataLoaded, value); }
        public override string Title => "Quản lý giáo viên";
        public override User User { get; protected set; }
        private ObservableCollection<Teacher> Teachers { get; set; }

        protected override void RegisterCommand()
        {
            ClickedNextCommand = new DelegateCommand(OnNext);
            ClickedPreviousCommand = new DelegateCommand(OnPreviousAsync);
            ClickedAddCommand = new DelegateCommand(OnAdd);
        }

        private async void AddTeacher(Teacher teacher, User user, Department department, Subject subject)
        {
            if (department == null || subject == null || user == null || teacher == null)
            {
                NotificationManager.ShowWarning("Thông không hợp lệ!.");
                return;
            }
            teacher.UserId = user.UserId;
            teacher.DepartmentId = department.DepartmentId;
            teacher.SubjectId = subject.SubjectId;
            var isAdded = await _teacherService.AddTeacher(teacher);
            if (!isAdded)
            {
                NotificationManager.ShowWarning("Thêm giáo viên thất bại!.");
                return;
            }
            NotificationManager.ShowWarning("Thêm giáo viên thành công!.");
            CloseDialog();
            await GetTeachers();
        }

        private async Task GetTeachers()
        {
            DataLoaded = false;
            var teachers = await _teacherService.GetTeachersBySize(DEFAULT_ROW, page);
            if (teachers?.Any() == false)
            {
                NotificationManager.ShowWarning("Không có giáo viên nào!.");
                return;
            }
            foreach (var teacher in teachers)
            {
                teacher.User = await _userService.GetUserAsync(teacher.UserId);
            }
            Teachers.Clear();
            Teachers.AddRange(teachers);
            DataLoaded = true;
        }

        private async void OnAdd()
        {
            var addTeacherView = new AddTeacherView();
            addTeacherView.SetAddTeacherEvent(AddTeacher);
            await ShowDialogHost(addTeacherView);
        }
        private async void OnNext()
        {
            page++;
            await GetTeachers();
        }

        private async void OnPreviousAsync()
        {
            page--;
            await GetTeachers();
        }
    }
}