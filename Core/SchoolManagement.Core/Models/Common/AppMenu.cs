using Avalonia.Controls;
using System.Collections.ObjectModel;

namespace SchoolManagement.Core.Models.Common
{
    public class AppMenu
    {
        public AppMenu()
        {
            Childs = new();
        }

        public string? Geometry { get; set; }
        public string? Label { get; set; }
        public string? Roles { get; set; } = string.Empty;
        public Type? Type { get; set; }
        public UserControl? View => (UserControl)Activator.CreateInstance(Type);
        public string? ViewName { get; set; }
        public ObservableCollection<AppMenu> Childs { get; set; }
    }
}