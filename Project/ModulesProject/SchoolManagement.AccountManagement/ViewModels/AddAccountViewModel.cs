using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Windows.Input;

namespace SchoolManagement.AccountManagement.ViewModels
{
    internal class AddAccountViewModel : BaseRegionViewModel
    {
        private bool isStudent;
        private Role role;
        private User newUser;

        public AddAccountViewModel()
        {
            User = RootContext.CurrentUser;
            NewUser = new();
        }

        public Action<User> AddUser { get; set; }
        public ICommand ClickedExit { get; set; }
        public ICommand ClickedOK { get; set; }
        public bool IsStudent { get => isStudent; set => SetProperty(ref isStudent, value); }
        public User NewUser { get => newUser; set => SetProperty(ref newUser, value); }
        public override string Title => "Thêm tài khoản";

        public override User User { get; protected set; }

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
            AddUser?.Invoke(NewUser);
            NewUser = new();
        }
    }
}