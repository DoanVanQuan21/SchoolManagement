using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using SchoolManagement.StudentManagement.Views.Dialogs;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.StudentManagement.ViewModels
{
    internal class StudentManagementViewModel : BaseRegionViewModel
    {
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;
        private bool dataLoaded = false;

        public StudentManagementViewModel()
        {
            _studentService = Ioc.Resolve<IStudentService>();
            _userService = Ioc.Resolve<IUserService>();
            User = RootContext.CurrentUser;
            Students = new();
            GetStudents().GetAwaiter();
        }

        public bool DataLoaded { get => dataLoaded; set => SetProperty(ref dataLoaded, value); }
        public ICommand ClickedAddCommand { get; set; }
        public ICommand ClickedNextCommand { get; set; }
        public ICommand ClickedPreviousCommand { get; set; }
        public override string Title => "Quản lý học sinh";
        public override User User { get; protected set; }
        private ObservableCollection<Student> Students { get; set; }

        protected override void RegisterCommand()
        {
            ClickedNextCommand = new DelegateCommand(OnNext);
            ClickedPreviousCommand = new DelegateCommand(OnPreviousAsync);
            ClickedAddCommand = new DelegateCommand(OnAdd);
        }

        private async Task GetStudents()
        {
            DataLoaded = false;
            var students = await _studentService.GetStudentsBySize(DEFAULT_ROW, page);
            if (students?.Any() == false)
            {
                NotificationManager.ShowWarning("Không có sinh viên nào!.");
                return;
            }
            foreach (var student in students)
            {
                student.User = await _userService.GetUserAsync(student.UserId);
            }
            Students.Clear();
            Students.AddRange(students);
            DataLoaded = true;
        }

        private async void OnAdd()
        {
            var addStudentView = new AddStudentView();
            addStudentView.SetAddStudentEvent(AddStudent);
            await ShowDialogHost(addStudentView);
        }

        private async void AddStudent(Student student, User user)
        {
            if (user == null || student == null)
            {
                NotificationManager.ShowWarning("Thông không hợp lệ!.");
                return;
            }
            student.UserId = user.UserId;
            var isAdded = await _studentService.AddStudent(student);
            if (!isAdded)
            {
                NotificationManager.ShowWarning("Thêm học sinh thất bại!.");
                return;
            }
            NotificationManager.ShowWarning("Thêm học sinh thành công!.");
            CloseDialog();
            await GetStudents();
        }

        private async void OnNext()
        {
            page++;
            await GetStudents();
        }

        private async void OnPreviousAsync()
        {
            page--;
            await GetStudents();
        }
    }
}