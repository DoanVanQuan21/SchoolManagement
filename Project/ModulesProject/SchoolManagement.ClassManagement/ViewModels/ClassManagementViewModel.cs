using Prism.Commands;
using SchoolManagement.ClassManagement.Views.Dialogs;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.ClassManagement.ViewModels
{
    internal class ClassManagementViewModel : BaseRegionViewModel
    {
        private Class selectedClass;
        private bool dataLoaded;
        private readonly IClassService _classService;
        private readonly ITeacherService _teacherService;
        private readonly IUserService _userService;
        public override string Title => Util.GetResourseString("ClassManagement_Label");

        public override User User { get; protected set; }

        public ClassManagementViewModel()
        {
            _classService = Ioc.Resolve<IClassService>();
            _teacherService = Ioc.Resolve<ITeacherService>();
            _userService = Ioc.Resolve<IUserService>();
            User = RootContext.CurrentUser;
            Classes = new();
            Teachers = new();
            GetClasses().GetAwaiter();
        }

        public ICommand ClickedAddClassCommand { get; set; }
        public ICommand ClickedDeleteCommand { get; set; }
        public ICommand ClickedNextCommand { get; set; }
        public ICommand ClickedPreviousCommand { get; set; }
        public ICommand ClickedUpdateCommand { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public ObservableCollection<Teacher> Teachers { get; set; }
        public Class SelectedClass { get => selectedClass; set => SetProperty(ref selectedClass, value); }
        public bool DataLoaded { get => dataLoaded; set => SetProperty(ref dataLoaded, value); }

        protected override void RegisterCommand()
        {
            ClickedNextCommand = new DelegateCommand(OnNext);
            ClickedPreviousCommand = new DelegateCommand(OnPreviousAsync);
            ClickedAddClassCommand = new DelegateCommand(OnAddClass);
            ClickedUpdateCommand = new DelegateCommand(OnUpdate);
            ClickedDeleteCommand = new DelegateCommand(OnDelete);
            base.RegisterCommand();
        }

        private async void OnDelete()
        {
            var _confirmDeleteClassView = new ConfirmDeleteClassView();
            _confirmDeleteClassView.SetOnOkClicked(DeleteClass);
            await ShowDialogHost(_confirmDeleteClassView);
        }

        private async void DeleteClass()
        {
            var deleteOK = await _classService.DeleteClass(SelectedClass.ClassId);
            if (!deleteOK)
            {
                NotificationManager.ShowWarning(string.Format(Util.GetResourseString("DeleteClassError_Message"), SelectedClass.ClassName));
                return;
            }
            NotificationManager.ShowSuccess(string.Format(Util.GetResourseString("DeleteClassSuccess_Message"), SelectedClass.ClassName));
            CloseDialog();
            await GetClasses();
        }

        private void OnUpdate()
        {
        }

        private async void OnAddClass()
        {
            var addClassView = new AddClassView();
            addClassView.SetAddClassAction(AddClass);
            addClassView.ViewModel.Teachers.AddRange(Teachers);
            await ShowDialogHost(addClassView);
        }

        private async void AddClass(Class _class)
        {
            var isAdded = await _classService.AddClass(_class);
            if (!isAdded)
            {
                NotificationManager.ShowWarning(string.Format(Util.GetResourseString("AddClassError_Message"), _class.ClassName));
                return;
            }
            NotificationManager.ShowSuccess(string.Format(Util.GetResourseString("AddClassSuccess_Message"), _class.ClassName));
            CloseDialog();
            await GetClasses();
        }

        private async void OnPreviousAsync()
        {
            page--;
            await GetClasses();
        }

        private async void OnNext()
        {
            page++;
            await GetClasses();
        }

        private async Task GetClasses()
        {
            DataLoaded = false;
            var classes = await _classService.GetClassesBySize(DEFAULT_ROW, page);
            if (classes?.Any() == false)
            {
                DataLoaded = true;
                NotificationManager.ShowWarning(Util.GetResourseString("RecordsEmpty_Message"));
                return;
            }
            Classes.Clear();
            await Task.Delay(1500);
            Classes.AddRange(classes);
            await GetTeacherNoHomeroom();

            DataLoaded = true;
        }

        private async Task GetTeacherNoHomeroom()
        {
            var teachers = new ObservableCollection<Teacher>();
            foreach (var c in Classes)
            {
                var teacher = await _teacherService.GetTeacherByTeacherID(c.TeacherId);
                if (teacher == null)
                {
                    continue;
                }
                teachers.Add(teacher);
            }
            var allTeacher = await _teacherService.GetTeachers();
            var teachersNotHomeroom = allTeacher.Except(teachers);
            foreach (var teacher in teachersNotHomeroom)
            {
                teacher.User = await _userService.GetUserAsync(teacher.UserId);
            }
            Teachers.Clear();
            Teachers.AddRange(teachersNotHomeroom);
        }
    }
}