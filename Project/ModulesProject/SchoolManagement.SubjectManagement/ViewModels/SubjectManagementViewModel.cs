using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.SubjectManagement.ViewModels
{
    internal class SubjectManagementViewModel : BaseRegionViewModel
    {
        private readonly ISubjectService _subjectService;
        private bool dataLoaded = false;
        private Subject selectedSubject;

        public SubjectManagementViewModel()
        {
            _subjectService = Ioc.Resolve<ISubjectService>();
            User = RootContext.CurrentUser;
            Subjects = new();
            GetSubjects().GetAwaiter();
        }

        public ICommand ClickedAddSubjectCommand { get; set; }
        public ICommand ClickedDeleteCommand { get; set; }
        public ICommand ClickedNextCommand { get; set; }
        public ICommand ClickedPreviousCommand { get; set; }
        public ICommand ClickedUpdateCommand { get; set; }
        public bool DataLoaded { get => dataLoaded; set => SetProperty(ref dataLoaded, value); }
        public Subject SelectedSubject { get => selectedSubject; set => SetProperty(ref selectedSubject, value); }
        public ObservableCollection<Subject> Subjects { get; set; }
        public override string Title => "Quản lý môn học";

        public override User User { get; protected set; }

        protected override void RegisterCommand()
        {
            ClickedNextCommand = new DelegateCommand(OnNext);
            ClickedPreviousCommand = new DelegateCommand(OnPreviousAsync);
            ClickedAddSubjectCommand = new DelegateCommand(OnAddSubject);
            ClickedUpdateCommand = new DelegateCommand(OnUpdate);
            ClickedDeleteCommand = new DelegateCommand(OnDelete);
            base.RegisterCommand();
        }

        private async Task GetSubjects()
        {
            DataLoaded = false;
            var subjects = await _subjectService.GetSubjectsBySize(DEFAULT_ROW, page);
            if (subjects?.Any() == false)
            {
                DataLoaded = true;

                NotificationManager.ShowWarning("Không có môn học nào");
                return;
            }
            Subjects.Clear();
            await Task.Delay(1500);
            Subjects.AddRange(subjects);
            DataLoaded = true;
        }

        private void OnAddSubject()
        {
        }

        private void OnDelete()
        {
        }

        private async void OnNext()
        {
            page++;
            await GetSubjects();
        }

        private async void OnPreviousAsync()
        {
            page--;
            await GetSubjects();
        }

        private void OnUpdate()
        {
        }
    }
}