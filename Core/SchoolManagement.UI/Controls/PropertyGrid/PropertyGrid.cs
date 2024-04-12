using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Layout;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.UI.Helpers;
using System.ComponentModel;
using System.Reflection;

namespace SchoolManagement.UI.Controls.PropertyGrid
{
    public class PropertyGrid : TemplatedControl
    {
        private readonly string CONTENT_CONTROL_KEY = "PART_ContentControl";
        private readonly INotificationManager _notificationManager;

        public static readonly StyledProperty<object> SelectedObjectProperty =
            AvaloniaProperty.Register<PropertyGrid, object>(nameof(SelectedObject));

        public static readonly StyledProperty<Columns> ColumnProperty =
            AvaloniaProperty.Register<PropertyGrid, Columns>(nameof(ColumnProperty));

        public PropertyGrid()
        {
            _notificationManager = Ioc.Resolve<INotificationManager>();
        }

        public object SelectedObject
        {
            get => GetValue(SelectedObjectProperty);
            set => SetValue(SelectedObjectProperty, value);
        }

        public Columns Column
        {
            get => GetValue(ColumnProperty);
            set => SetValue(ColumnProperty, value);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            var contenCotrol = e.NameScope.Find(CONTENT_CONTROL_KEY) as ContentPresenter;
            if (contenCotrol != null)
            {
                _notificationManager.ShowError($"{CONTENT_CONTROL_KEY} không tồn tại hoặc bị lỗi!");
                return;
            }
            var properties = SelectedObject.GetType().GetProperties().Where(prop => PropertyHelper.GetBrowsable(prop)).ToList();

            GenerateEditor(contenCotrol, properties);
            base.OnApplyTemplate(e);
        }

        private void GenerateEditor(ContentPresenter content, List<PropertyInfo> properties)
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
                widthType = new GridLength(300, GridUnitType.Pixel);
                OneColumn(properties, col, widthType, content);
                return;
            }
            widthType = new GridLength(3, GridUnitType.Star);
            TwoColumn(properties, col, widthType, content);
        }

        private void TwoColumn(List<PropertyInfo> properties, int col, GridLength gridLength, ContentPresenter content)
        {
            Grid grid = new()
            {
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

        private void OneColumn(List<PropertyInfo> properties, int col, GridLength gridLength, ContentPresenter content)
        {
            Grid grid = new()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            for (int i = 0; i < col; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = gridLength });
            }
            var labels = new List<Control>();
            var inputControls = new List<Control>();
            int count = 0;

            foreach (var property in properties)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
                inputControls.Add(CreateInputControl(property));
                labels.Add(CreateLabelForNameProperty(property));
                Grid.SetColumn(labels[count], 0);
                Grid.SetColumn(inputControls[count], 1);
                Grid.SetRow(labels[count], count);
                Grid.SetRow(inputControls[count], count);
                count++;
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

        private Control CreateLabelForNameProperty(PropertyInfo propertyInfo)
        {
            var attribute = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false).ToList();
            var att = attribute.First() as DisplayNameAttribute;
            TextBlock textBlock = new()
            {
                Text = att?.DisplayName,
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return textBlock;
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
                    Height = 40
                };
            }
            if (type.IsSubclassOf(typeof(Enum)))
            {
                return new ComboBox()
                {
                    ItemsSource = Enum.GetValues(type),
                    Margin = new Thickness(10),
                    Height = 40
                };
            }
            if (type.Name == (nameof(DateTime)))
            {
                return new DatePicker()
                {
                };
            }
            if (type == typeof(int) || type == typeof(double) || type == typeof(long) || type == typeof(float))
            {
                return new NumericUpDown()
                {
                    Margin = new Thickness(10),
                    Height = 40
                };
            }
            return new TextBox()
            {
                Margin = new Thickness(10),
                Height = 40
            };
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
            return TextBox.TextProperty;
        }
    }

    public enum Columns
    {
        One,
        Two
    }
}