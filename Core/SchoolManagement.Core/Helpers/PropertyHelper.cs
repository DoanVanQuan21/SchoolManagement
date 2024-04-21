using SchoolManagement.GlobalShared.CustomAttributes;
using System.ComponentModel;
using System.Reflection;

namespace SchoolManagement.Core.Helpers
{
    public class PropertyHelper
    {
        public static string GetDisplayName(PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), true).ToList();
            if (attributes == null || attributes.Count <= 0)
            {
                return propertyInfo.Name;
            }
            var attribute = attributes.FirstOrDefault() as DisplayNameAttribute;
            return attribute?.DisplayName ?? string.Empty;
        }
        public static bool GetBrowsable(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof(BrowsableAttribute), false);
            if (attributes?.Any() == false)
            {
                return true;
            }
            return false;
        }
        public static bool IsHeaderExcel(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof(IsHeaderExcelAttribute), false);
            if (attributes?.Any() == false)
            {
                return true;
            }
            return false;
        }
        public static bool IsID(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof(IsIDAttribute), false);
            if (attributes?.Any() == false)
            {
                return false;
            }
            return true;
        }
    }
}