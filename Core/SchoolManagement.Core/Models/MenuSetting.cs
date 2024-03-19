using Avalonia.Controls;

namespace SchoolManagement.Core.Models
{
    public class MenuSetting
    {
        public string? Label { get; set; }
        public string? ViewName { get; set; }
        public Type? Type { get; set; }
        public UserControl? View => (UserControl)Activator.CreateInstance(Type);
        public string? IconPath { get; set; }
    }
}