using SchoolManagement.Core.Models.Common;
using System.Collections.ObjectModel;

namespace SchoolManagement.Core.Context
{
    public class RootContext
    {
        public static Dictionary<string, bool> Modules = new();
        public static ObservableCollection<AppMenu> AppMenus = new();
    }
}