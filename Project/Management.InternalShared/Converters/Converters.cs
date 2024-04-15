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
            return GetFullName(value).GetAwaiter().GetResult();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private Task<string> GetFullName(object? value)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    var studentService = Ioc.Resolve<IStudentService>();
                    var userService = Ioc.Resolve<IUserService>();
                    var student = studentService.GetStudent((int)value);
                    Debug.WriteLine(student.User?.ToString());
                    var fullName = userService.GetFullname(student.UserId);
                    return fullName;
                }
                catch (Exception)
                {
                    return "NaN";
                }
            });
        }
    }
}