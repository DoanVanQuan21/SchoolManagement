using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Models;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Windows.Input;

namespace SchoolManagement.Database.ViewModels
{
    public class RegisterDatabaseViewModel : BaseRegionViewModel
    {
        public RegisterDatabaseViewModel()
        {
            User = new();
        }

        public override string Title => "Cấu hình database";

        public override User User { get; protected set; }
        public ICommand ClickedOKCommand { get; set; }
        protected override void RegisterCommand()
        {
            ClickedOKCommand = new DelegateCommand(OnOK);
            base.RegisterCommand();
        }

        private void OnOK()
        {
            //EventAggregator.GetEvent<ConfigDatabaseSuccessEvent>().Publish();
            //BootSetting.IsSelectorServer = true;
        }
    }
}