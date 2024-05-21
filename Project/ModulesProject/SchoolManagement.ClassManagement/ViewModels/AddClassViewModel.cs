using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.ClassManagement.ViewModels
{
    public class AddClassViewModel : BaseRegionViewModel
    {
        private readonly IClassService _classService;
        private Teacher teacher;

        public AddClassViewModel()
        {
            _classService = Ioc.Resolve<IClassService>();
            User = RootContext.CurrentUser;
            Class = new();
            Teachers = new();
        }

        public ICommand ClickedExit { get; set; }
        public ICommand ClickedOK { get; set; }
        public Action<Class> AddClass { get; set; }

        protected override void RegisterCommand()
        {
            ClickedExit = new DelegateCommand(OnExit);
            ClickedOK = new DelegateCommand(OnOK);
            base.RegisterCommand();
        }

        public ObservableCollection<Teacher> Teachers { get; set; }
        public Teacher Teacher
        { get => teacher; set { SetProperty(ref teacher, value); UpdateClassInfor(); } }

        private void OnOK()
        {
            AddClass?.Invoke(Class);
        }

        private void OnExit()
        {
            CloseDialog();
        }

        private void UpdateClassInfor()
        {
            Class.TeacherId = Teacher.TeacherId;
        }

        public Class Class { get; set; }
        public override string Title => Util.GetResourseString("AddClass_Label");

        public override User User { get; protected set; }
    }
}