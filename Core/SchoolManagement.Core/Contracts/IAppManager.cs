using SchoolManagement.Core.Models;
using SchoolManagement.Core.Models.Common;

namespace SchoolManagement.Core.Contracts
{
    public interface IAppManager
    {
        AppRegion AppRegion { get; set; }
        BootSetting? BootSetting { get; set; }
        List<Gender> Genders { get; }
        void Save();
        void Load();
    }
}