using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Models.Common;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace SchoolManagement.Core.Models
{
    public class BootSetting : BindableBase
    {
        private string? version;
        private Theme currentTheme = Theme.Dark;
        private bool isSelectedDatabase = false;

        public BootSetting()
        {
            ID = Guid.NewGuid();
            Version = "SOFT_VER_1";
            ServerInfors = new() { new() };
            CurrentServerInfor = new()
            {
                ServerName = "192.168.1.100",
                User = "schoolmanagement",
                Password = "123",
            };
        }

        public Guid ID { get; set; }

        public Theme CurrentTheme
        { get => currentTheme; set { SetProperty(ref currentTheme, value); } }

        public string? Version
        {
            get { return version; }
            set { SetProperty(ref version, value); }
        }

        public bool IsSelectedDatabase
        {
            get => isSelectedDatabase;
            set { SetProperty(ref isSelectedDatabase, value); }
        }

        public ObservableCollection<ServerInfor> ServerInfors { get; set; }
        public ServerInfor CurrentServerInfor { get; set; }
    }
}