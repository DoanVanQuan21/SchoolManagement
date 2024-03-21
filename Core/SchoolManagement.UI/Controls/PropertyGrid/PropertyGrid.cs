using Avalonia;
using Avalonia.Controls;

namespace SchoolManagement.UI.Controls.PropertyGrid
{
    public class PropertyGrid : Control
    {
        public static readonly StyledProperty<object> SelectedObjectProperty = AvaloniaProperty.Register<PropertyGrid, object>(nameof(SelectedObject));

        public object SelectedObject { get; set; }
    }
}