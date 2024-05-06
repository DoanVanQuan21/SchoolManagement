using Prism.Commands;
using SchoolManagement.AccountManagement.Views.Dialogs;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.AccountManagement.ViewModels
{
    internal class AccountManagementViewModel : BaseRegionViewModel
    {
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private bool dataLoaded = false;
        private User selectedUser;

        public AccountManagementViewModel()
        {
            _userService = Ioc.Resolve<IUserService>();
            _studentService = Ioc.Resolve<IStudentService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            User = RootContext.CurrentUser;
            Users = new();
            GetAccounts().GetAwaiter();
        }

        public ICommand ClickedDeleteUserCommand { get; set; }
        public ICommand ClickedNextCommand { get; set; }
        public ICommand ClickedPreviousCommand { get; set; }
        public ICommand ClickedResetPasswordCommand { get; set; }
        public ICommand ClickedAddCommand { get; set; }
        public bool DataLoaded { get => dataLoaded; set => SetProperty(ref dataLoaded, value); }
        public User SelectedUser { get => selectedUser; set => SetProperty(ref selectedUser, value); }
        public override string Title => "Quản lý tài khoản";

        public override User User { get; protected set; }
        public ObservableCollection<User> Users { get; protected set; }

        protected override void RegisterCommand()
        {
            ClickedResetPasswordCommand = new DelegateCommand(OnResetPassword);
            ClickedDeleteUserCommand = new DelegateCommand(OnDeleteUser);
            ClickedNextCommand = new DelegateCommand(OnNext);
            ClickedPreviousCommand = new DelegateCommand(OnPreviousAsync);
            ClickedAddCommand = new DelegateCommand(OnAdd);
            base.RegisterCommand();
        }

        private async void OnAdd()
        {
            var addAccountView = new AddUserView();
            addAccountView.SetAddAccountAction(AddAccount);
            await ShowDialogHost(addAccountView);
        }

        private async void AddAccount(User user)
        {
            var isAdded = await _userService.AddUser(user);
            if (!isAdded)
            {
                NotificationManager.ShowWarning("Thêm tài khoản không thành công!.");
                return;
            }
            await GetAccounts();
            NotificationManager.ShowSuccess($"Thêm tài khoản thành công!.");
        }

        private async Task GetAccounts()
        {
            DataLoaded = false;
            var users = await _userService.GetAccountsBySize(DEFAULT_ROW, page);
            if (users?.Any() == false)
            {
                DataLoaded = true;
                NotificationManager.ShowWarning("Không có tài khoản nào!.");
                return;
            }
            Users.Clear();
            await Task.Delay(1500);
            Users.AddRange(users);
            DataLoaded = true;
        }

        private void OnDeleteUser()
        {
        }

        private async void OnNext()
        {
            page++;
            await GetAccounts();
        }

        private async void OnPreviousAsync()
        {
            page--;
            await GetAccounts();
        }

        private void OnResetPassword()
        {
        }
    }
}