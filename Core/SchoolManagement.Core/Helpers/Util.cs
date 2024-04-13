using Avalonia;
using Avalonia.Controls;

namespace SchoolManagement.Core.Helpers
{
    public class Util
    {
        public static string GetResourseString(string key)
        {
            try
            {
                Application.Current.Resources.TryGetResource(key, Application.Current.ActualThemeVariant, out var value);
                if (value == null)
                {
                    return string.Empty;
                }
                return value.ToString().Trim();
            }
            catch (Exception e)
            {
                //TODO
                return string.Empty;
            }
        }
    }
}