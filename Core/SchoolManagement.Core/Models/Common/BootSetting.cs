using Avalonia.Styling;
using Prism.Mvvm;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.Common;

namespace SchoolManagement.Core.Models
{
    public class BootSetting : BindableBase
    {
        private Language? currentLanguage;
        private ThemeVariant currentTheme = ThemeVariant.Light;
        private ServerInfor serverInfor;
        private string? version;

        public BootSetting()
        {
            ID = Guid.NewGuid();
            Version = "SOFT_VER_1";
            CurrentLanguage = RootContext.Languages.FirstOrDefault();
        }

        public Language? CurrentLanguage { get => currentLanguage; set => SetProperty(ref currentLanguage, value); }

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