using Avalonia.Controls.ApplicationLifetimes;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.Core.Context
{
    public class RootContext
    {
        public static Dictionary<string, bool> Modules = new();
        public static ObservableCollection<AppMenu> AppMenus = new();
        public static IApplicationLifetime ApplicationLifetime { get; set; }
        public static Stack<Type> PreviewMainViews = new();
        public static User CurrentUser { get; set; } = new User();
    }
}