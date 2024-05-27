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
        private readonly IClassService _classService;
        private readonly ITeacherService _teacherService;
        private readonly IUserService _userService;
        private bool dataLoaded;
        private Class selectedClass;

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

        public ObservableCollection<Class> Classes { get; set; }
        public ICommand ClickedAddClassCommand { get; set; }
        public ICommand ClickedDeleteCommand { get; set; }
        public ICommand ClickedNextCommand { get; set; }
        public ICommand ClickedPreviousCommand { get; set; }
        public ICommand ClickedUpdateCommand { get; set; }
        public bool DataLoaded { get => dataLoaded; set => SetProperty(ref dataLoaded, value); }
        public Class SelectedClass { get => selectedClass; set => SetProperty(ref selectedClass, value); }
        public ObservableCollection<Teacher> Teachers { get; set; }
        public override string Title => Util.GetResourseString("ClassManagement_Label");

        public override User User { get; protected set; }

        protected override void RegisterCommand()
        {
            ClickedNextCommand = new DelegateCommand(OnNext);
            ClickedPreviousCommand = new DelegateCommand(OnPreviousAsync);
            ClickedAddClassCommand = new DelegateCommand(OnAddClass);
            ClickedUpdateCommand = new DelegateCommand(OnUpdate);
            ClickedDeleteCommand = new DelegateCommand(OnDelete);
            base.RegisterCommand();
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

        private async void EditClass(Class _class)
        {
            var isEdited = await _classService.EditClass(_class);
            if (!isEdited)
            {
                NotificationManager.ShowWarning(string.Format(Util.GetResourseString("EditClassError_Message"), _class.ClassName));
                return;
            }
            NotificationManager.ShowSuccess(string.Format(Util.GetResourseString("EditClassSuccess_Message"), _class.ClassName));
            CloseDialog();
            await GetClasses();
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
            DataLoaded = true;
        }

        private async void OnAddClass()
        {
            var addClassView = new AddClassView();
            addClassView.SetAddClassAction(AddClass);
            addClassView.ViewModel.Teachers.AddRange(Teachers);
            await ShowDialogHost(addClassView);
        }

        private async void OnDelete()
        {
            var _confirmDeleteClassView = new ConfirmDeleteClassView();
            _confirmDeleteClassView.SetOnOkClicked(DeleteClass);
            await ShowDialogHost(_confirmDeleteClassView);
        }

        private async void OnNext()
        {
            page++;
            await GetClasses();
        }

        private async void OnPreviousAsync()
        {
            page--;
            await GetClasses();
        }

        private async void OnUpdate()
        {
            var editView = new EditClassView();
            editView.ViewModel.Class = SelectedClass;
            editView.SetEditClassAction(EditClass);
            await ShowDialogHost(editView);
        }
    }
}