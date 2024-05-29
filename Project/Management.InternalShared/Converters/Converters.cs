using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using SchoolManagement.Core.avalonia;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Diagnostics;
using System.Globalization;

namespace Management.InternalShared.Converters
{
    public class StudentIDConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            TaskCompletionSource<string> tsk = new();

            return tsk.Task.Result;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return "0";
        }

        
    }

    public class MinWidthFollowPlatformConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var isMobilePlatform = (bool)value;
            if (isMobilePlatform)
            {
                return 50;
            }
            return 500;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MinHeightFollowPlatformConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var isMobilePlatform = (bool)value;
            if (isMobilePlatform)
            {
                return 350;
            }
            var isParsed = int.TryParse((string)parameter,out var val);
            if(isParsed)
            {
                return val;
            }
            return 500;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class EnumToItemsSourceConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var enums = Enum.GetValues(value?.GetType());
            var values = Enum.GetNames(value?.GetType());
            return values;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NumerRowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is DataGridRow row)
                {
                    return (row.GetIndex() + 1).ToString();
                }
                else
                {
                    return "*"; // Default value if not a DataGridRow
                }
            }
            catch
            {
                return "*"; // Default value in case of an exception
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PermissionConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter == null || value == null)
            {
                return false;
            }
            var roles = ((string)parameter).Split(",");
            if (roles.Length <= 0)
            {
                return false;
            }
            var actualRole = value.ToString();
            var isHave = roles.FirstOrDefault(r => r == actualRole);
            if (isHave == null)
            {
                return false;
            }

            return true;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VisibleProgressConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Count < 2 || !(values[0] is bool) || !(values[1] is bool))
                return AvaloniaProperty.UnsetValue;

            return (bool)values[0] && !(bool)values[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VisibleDatagridConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Count < 2 || !(values[0] is bool) || !(values[1] is bool))
                return AvaloniaProperty.UnsetValue;

            return (bool)values[0] && (bool)values[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}