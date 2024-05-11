using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.StudentManagement.ViewModels
{
    public class AddStudentViewModel : BaseRegionViewModel
    {
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private Student student;
        private User currentUser;

        public AddStudentViewModel()
        {
            _userService = Ioc.Resolve<IUserService>();
            _studentService = Ioc.Resolve<IStudentService>();
            User = RootContext.CurrentUser;
            Users = new();
            Student = new();
            GetAccountOfStudent();
        }

        public override string Title => "Thêm học sinh";

        public override User User { get; protected set; }
        public ObservableCollection<User> Users { get; set; }
        public User CurrentUser { get => currentUser; set => SetProperty(ref currentUser, value); }
        public Action<Student,User> AddStudentAction { get; set; }
        public ICommand ClickedExit { get; set; }
        public ICommand ClickedOK { get; set; }
        public Student Student { get => student; set => SetProperty(ref student, value); }

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
            AddStudentAction?.Invoke(Student, CurrentUser);
        }

        private async void GetAccountOfStudent()
        {
            var accounts = await _userService.GetAccountOfStudents();
            Users.Clear();
            foreach (var account in accounts)
            {
                var student = await _studentService.GetStudentByUserID(account.UserId);
                if (student != null)
                {
                    continue;
                }
                Users.Add(account);
            }
        }
    }
}