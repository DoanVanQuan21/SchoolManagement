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
    public class EditClassViewModel : BaseRegionViewModel
    {
        private readonly IClassService _classService;
        private Class @class;

        public EditClassViewModel()
        {
            _classService = Ioc.Resolve<IClassService>();
            User = RootContext.CurrentUser;
            Class = new();
            Teachers = new();
        }

        public ICommand ClickedExit { get; set; }
        public ICommand ClickedOK { get; set; }
        public Action<Class> EditClass { get; set; }

        protected override void RegisterCommand()
        {
            ClickedExit = new DelegateCommand(OnExit);
            ClickedOK = new DelegateCommand(OnOK);
            base.RegisterCommand();
        }

        public ObservableCollection<Teacher> Teachers { get; set; }

        private void OnOK()
        {
            EditClass?.Invoke(Class);
        }

        private void OnExit()
        {
            CloseDialog();
        }

        public Class Class { get => @class; set => SetProperty(ref @class, value); }
        public override string Title => Util.GetResourseString("AddClass_Label");

        public override User User { get; protected set; }
    }
}