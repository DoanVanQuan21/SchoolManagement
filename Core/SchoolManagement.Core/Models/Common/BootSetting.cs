using Prism.Mvvm;
using SchoolManagement.Core.Constants;

namespace SchoolManagement.Core.Models
{
    public class BootSetting : BindableBase
    {
        private string? version;
        private Theme currentTheme = Theme.Dark;

        public BootSetting()
        {
            ID = Guid.NewGuid();
            Version = "SOFT_VER_1";
        }

        public Guid ID { get; set; }

        public Theme CurrentTheme
        { get => currentTheme; set { SetProperty(ref currentTheme, value); } }

        public string? Version
        {
            get { return version; }
            set { SetProperty(ref version, value); }
        }
    }
}