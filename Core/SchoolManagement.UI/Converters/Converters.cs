using Avalonia.Data.Converters;
using System.Globalization;

namespace SchoolManagement.UI.Converters
{
    public class PermissionConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter is not string)
            {
                return false;
            }
            if (parameter is null || value is null)
            {
                return false;
            }
            var roles = ((string)parameter).Split(',');
            if (roles == null || roles?.Length < 0)
            {
                return false;
            }
            var role = roles.FirstOrDefault(r => r == value.ToString());
            if (role == null)
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
}