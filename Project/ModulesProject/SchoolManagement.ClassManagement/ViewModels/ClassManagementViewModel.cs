using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.InkML;
using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using SchoolManagement.EntityFramework.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.ClassManagement.ViewModels
{
    internal class ClassManagementViewModel : BaseRegionViewModel
    {
        private Class selectedClass;
        private bool dataLoaded;
        private readonly IClassService _classService;
        public override string Title => "Quản lý lớp học";

        public override User User { get; protected set; }

        public ClassManagementViewModel()
        {
            _classService = Ioc.Resolve<IClassService>();
            User = RootContext.CurrentUser;
            Classes = new();
            GetClasses().GetAwaiter();
        }

        public ICommand ClickedAddSubjectCommand { get; set; }
        public ICommand ClickedDeleteCommand { get; set; }
        public ICommand ClickedNextCommand { get; set; }
        public ICommand ClickedPreviousCommand { get; set; }
        public ICommand ClickedUpdateCommand { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public Class SelectedClass { get => selectedClass; set => SetProperty(ref selectedClass, value); }
        public bool DataLoaded { get => dataLoaded; set => SetProperty(ref dataLoaded, value); }

        protected override void RegisterCommand()
        {
            ClickedNextCommand = new DelegateCommand(OnNext);
            ClickedPreviousCommand = new DelegateCommand(OnPreviousAsync);
            ClickedAddSubjectCommand = new DelegateCommand(OnAddSubject);
            ClickedUpdateCommand = new DelegateCommand(OnUpdate);
            ClickedDeleteCommand = new DelegateCommand(OnDelete);
            base.RegisterCommand();
        }

        private void OnDelete()
        {
        }

        private void OnUpdate()
        {
        }

        private void OnAddSubject()
        {
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
                NotificationManager.ShowWarning("Không có bản ghi nào!.");
                return;
            }
            Classes.Clear();
            await Task.Delay(1500);
            Classes.AddRange(classes);
            DataLoaded = true;
        }
    }
}