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
}