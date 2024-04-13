using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Styling;
using DynamicData;
using SchoolManagement.UI.Helpers;
using System.ComponentModel;
using System.Reflection;

namespace SchoolManagement.UI.Controls.PropertyGrid
{
    public enum Columns
    {
        One,
        Two
    }

    public class PropertyGrid : TemplatedControl, IStyleable
    {
        public static readonly StyledProperty<Columns> ColumnProperty =
            AvaloniaProperty.Register<PropertyGrid, Columns>(nameof(Column), Columns.Two);

        public static readonly StyledProperty<object> SelectedObjectProperty =
            AvaloniaProperty.Register<PropertyGrid, object>(nameof(SelectedObject));

        private readonly string Accent = "accent";
        private readonly string CONTENT_CONTROL_KEY = "PART_ContentControl";
        private readonly string Danger = "danger";
        private readonly string Success = "success";
        private readonly string Warning = "warning";

        static PropertyGrid()
        {
            var t = 0;
        }

        public Columns Column
        {
            get => GetValue(ColumnProperty);
            set => SetValue(ColumnProperty, value);
        }

        public object SelectedObject
        {
            get => GetValue(SelectedObjectProperty);
            set => SetValue(SelectedObjectProperty, value);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            if (OperatingSystem.IsAndroid() || OperatingSystem.IsIOS())
            {
                Column = Columns.One;
            }
            UpdateTemplate(e);
        }

        private Control CreateInputControl(PropertyInfo propertyInfo)
        {
            var inputControl = CreateInputFromType(propertyInfo.PropertyType, propertyInfo);
            Binding binding = new(propertyInfo.Name)
            {
                Source = SelectedObject,
                Mode = BindingMode.TwoWay
            };
            inputControl.Bind(GetInputControlValueProperty(inputControl), binding);
            return inputControl;
        }

        private Control CreateInputFromType(Type type, PropertyInfo property)
        {
            if (type == typeof(string))
            {
                return new TextBox()
                {
                    Margin = new Thickness(10),
                    Classes = { Accent }
                };
            }
            if (type.IsSubclassOf(typeof(Enum)))
            {
                return new ComboBox()
                {
                    ItemsSource = Enum.GetValues(type),
                    Margin = new Thickness(10),
                    Classes = { Accent }
                };
            }

            if (type == typeof(int) || type == typeof(double) || type == typeof(long) || type == typeof(float))
            {
                return new NumericUpDown()
                {
                    Margin = new Thickness(10),
                    Classes = { Accent }
                };
            }
            if (type == typeof(bool))
            {
                return new ToggleSwitch()
                {
                    Margin = new Thickness(10),
                    Classes = { "theme-solid", Accent }
                };
            }
            if (IsDateTime(type))
            {
                return new TextBox()
                {
                    Margin = new Thickness(10),
                    Classes = { Accent },
                    IsReadOnly = true
                };
            }
            return new TextBox()
            {
                Margin = new Thickness(10),
                Classes = { Accent }
            };
        }

        private Control CreateLabelForNameProperty(PropertyInfo propertyInfo)
        {
            var attribute = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false).ToList();
            var displayName = propertyInfo.Name;
            if (attribute.Count > 0)
            {
                displayName = (attribute.First() as DisplayNameAttribute).DisplayName;
            }
            TextBlock textBlock = new()
            {
                Text = displayName,
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return textBlock;
        }

        private Control CreateStackPanel(PropertyInfo property)
        {
            StackPanel stackPanel = new()
            {
                Orientation = Orientation.Vertical
            };
            var label = CreateLabelForNameProperty(property);
            var inputControl = CreateInputControl(property);
            stackPanel.Children.Add(label);
            stackPanel.Children.Add(inputControl);
            return stackPanel;
        }

        private void GenerateEditor(ContentControl content, List<PropertyInfo> properties)
        {
            content.Content = null;
            var col = 2;
            if (SelectedObject == null)
            {
                return;
            }
            GridLength widthType = new();
            if (Column == Columns.One)
            {
                widthType = new GridLength(1, GridUnitType.Star);
                OneColumn(properties, col, widthType, content);
                return;
            }
            widthType = new GridLength(3, GridUnitType.Star);
            TwoColumn(properties, col, widthType, content);
        }

        private AvaloniaProperty GetInputControlValueProperty(Control inputControl)
        {
            if (inputControl is ComboBox)
            {
                return ComboBox.SelectedValueProperty;
            }
            if (inputControl is TextBox)
            {
                return TextBox.TextProperty;
            }
            if (inputControl is NumericUpDown)
            {
                return NumericUpDown.ValueProperty;
            }
            if (inputControl is DatePicker)
            {
                return DatePicker.SelectedDateProperty;
            }
            if (inputControl is ToggleSwitch)
            {
                return ToggleSwitch.IsCheckedProperty;
            }
            return TextBox.TextProperty;
        }

        private bool IsDateTime(Type type)
        {
            if (type.GenericTypeArguments.Length <= 0)
            {
                return false;
            }
            var dateTimeType = type.GenericTypeArguments.FirstOrDefault(item => item.Name == nameof(DateTime));
            if (dateTimeType == null)
            {
                return false;
            }
            return true;
        }

        private void OneColumn(List<PropertyInfo> properties, int col, GridLength gridLength, ContentControl content)
        {
            Grid grid = new()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = gridLength });
            var labels = new List<Control>();
            var inputControls = new List<Control>();
            int count = 0;
            int propertyIndex = 0;
            for (int i = 0; i < properties.Count * 2; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            }
            foreach (var property in properties)
            {
                inputControls.Add(CreateInputControl(property));
                labels.Add(CreateLabelForNameProperty(property));
                Grid.SetColumn(labels[propertyIndex], 0);
                Grid.SetColumn(inputControls[propertyIndex], 0);
                for (int i = 0; i < 2; i++)
                {
                    if (i % 2 == 0)
                    {
                        Grid.SetRow(labels[propertyIndex], count);
                        count++;
                        continue;
                    }
                    Grid.SetRow(inputControls[propertyIndex], count);
                    count++;
                }
                propertyIndex++;
            }
            foreach (var label in labels)
            {
                grid.Children.Add(label);
            }
            foreach (var inputControl in inputControls)
            {
                grid.Children.Add(inputControl);
            }
            if (content == null)
            {
                return;
            }
            content.Content = grid;
        }

        private void SetGrid(List<Control> stackPanels, PropertyInfo property, int row, int col)
        {
            var stackPanel = CreateStackPanel(property);
            stackPanels.Add(stackPanel);
            Grid.SetColumn(stackPanel, col);
            Grid.SetRow(stackPanel, row);
        }

        private void TwoColumn(List<PropertyInfo> properties, int col, GridLength gridLength, ContentControl content)
        {
            Grid grid = new()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
            };
            for (int i = 0; i < col * 2; i++)
            {
                if (i == 0 || i == 3)
                {
                    var width = new GridLength(2, GridUnitType.Star);
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = width });
                    continue;
                }
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = gridLength });
            }
            int mid = properties.Count / 2;
            var residual = properties.Count % 2; // phần dư != 0 thì lẻ 1 property
            var stackPanels = new List<Control>();
            int count = 0;
            int row = 0;
            // init rowdefination
            for (int i = 0; i < mid + 1; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            }
            // set grid
            foreach (var property in properties)
            {
                if (residual == 0)
                {
                    if (count < mid)
                    {
                        SetGrid(stackPanels, property, row, 1);
                        count++;
                        row++;
                        continue;
                    }
                    if (count == mid)
                    {
                        row = 0;
                    }
                    SetGrid(stackPanels, property, row, 2);
                    count++;
                    row++;
                    continue;
                }
                if (count <= mid)
                {
                    SetGrid(stackPanels, property, row, 1);
                    count++;
                    row++;
                    continue;
                }
                if (count == mid + 1)
                {
                    row = 0;
                }
                SetGrid(stackPanels, property, row, 2);
                count++;
                row++;
            }
            foreach (var stackpanel in stackPanels)
            {
                grid.Children.Add(stackpanel);
            }
            if (content == null)
            {
                return;
            }
            content.Content = grid;
        }

        private void UpdateTemplate(TemplateAppliedEventArgs e)
        {
            var contenCotrol = e.NameScope.Find<ContentControl>(CONTENT_CONTROL_KEY);
            if (contenCotrol == null)
            {
                return;
            }
            var properties = SelectedObject.GetType().GetProperties().Where(prop => PropertyHelper.GetBrowsable(prop)).ToList();

            GenerateEditor(contenCotrol, properties);
        }
    }
}