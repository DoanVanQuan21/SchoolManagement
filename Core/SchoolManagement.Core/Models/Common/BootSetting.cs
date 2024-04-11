using Avalonia.Styling;
using Prism.Mvvm;
using SchoolManagement.Core.Models.Common;

namespace SchoolManagement.Core.Models
{
    public class BootSetting : BindableBase
    {
        private ThemeVariant currentTheme = ThemeVariant.Light;
        private ServerInfor serverInfor;
        private string? version;

        public BootSetting()
        {
            ID = Guid.NewGuid();
            Version = "SOFT_VER_1";
        }

        public ThemeVariant CurrentTheme
        { get => currentTheme; set { SetProperty(ref currentTheme, value); } }

        public Guid ID { get; set; }

        public ServerInfor ServerInfor
        { get => serverInfor; set { SetProperty(ref serverInfor, value); } }

        public string? Version
        {
            get { return version; }
            set { SetProperty(ref version, value); }
        }
    }
}