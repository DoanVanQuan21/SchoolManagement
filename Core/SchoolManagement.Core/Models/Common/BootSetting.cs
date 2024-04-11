using Avalonia.Styling;
using Prism.Mvvm;
using SchoolManagement.Core.Models.Common;

namespace SchoolManagement.Core.Models
{
    public class BootSetting : BindableBase
    {
        private string? version;
        private ThemeVariant currentTheme = ThemeVariant.Light;
        private ServerInfor serverInfor;

        public BootSetting()
        {
            ID = Guid.NewGuid();
            Version = "SOFT_VER_1";
        }

        public Guid ID { get; set; }

        public ThemeVariant CurrentTheme
        { get => currentTheme; set { SetProperty(ref currentTheme, value); } }

        public string? Version
        {
            get { return version; }
            set { SetProperty(ref version, value); }
        }

        public ServerInfor ServerInfor
        { get => serverInfor; set { SetProperty(ref serverInfor, value); } }
    }
}