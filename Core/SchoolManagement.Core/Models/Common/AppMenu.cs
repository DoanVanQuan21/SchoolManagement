using Avalonia.Controls;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace SchoolManagement.Core.Models.Common
{
    public class AppMenu : BindableBase
    {
        private string? geometry;
        private string? label;
        private string? roles = string.Empty;
        private Type? type;

        public AppMenu()
        {
            Childs = new();
        }

        public string? Geometry { get => geometry; set => SetProperty(ref geometry,value); }
        public string? Label { get => label; set => SetProperty(ref label, value); }
        public string? Roles { get => roles; set => SetProperty(ref roles, value); }
        public Type? Type { get => type; set => SetProperty(ref type, value); }

        public UserControl? View
        {
            get
            {
                try
                {
                    return (UserControl)Activator.CreateInstance(Type);
                }
                catch (Exception)
                {
                    return new();
                }
            }
        }

        public string? ViewName { get; set; }
        public ObservableCollection<AppMenu> Childs { get; set; }
    }
}