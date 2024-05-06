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

            GetFullName(value, tsk);
            return tsk.Task.Result;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return "0";
        }

        private void GetFullName(object? value, TaskCompletionSource<string> tsk)
        {
            var fullname = "";
            try
            {
                var studentService = Ioc.Resolve<IStudentService>();
                var userService = Ioc.Resolve<IUserService>();
                var student = studentService.GetStudent((int)value);
                Debug.WriteLine(student.User?.ToString());
                fullname = userService.GetFullname(student.UserId);
            }
            catch (Exception)
            {
                fullname = "NaN";
            }
            finally
            {
                tsk.SetResult(fullname);
            }
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