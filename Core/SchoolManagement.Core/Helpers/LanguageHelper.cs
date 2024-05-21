using Avalonia;
using Avalonia.Markup.Xaml.Styling;
using SchoolManagement.Core.Constants;

namespace SchoolManagement.Core.Helpers
{
    public class LanguageHelper
    {
        private static string messageResources = "";
        private static string labelResources = "";
        public static bool ChangeLanguage(Languages lang)
        {
            try
            {
                var mesRes = GetMessageResource(lang);
                var labelRes = GetLabelResource(lang);
                UpdateResource(mesRes, labelRes, 1,2);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void UpdateResource(string mesResource,string labelResource, int mesPos,int labelPos)
        {
            ResourceInclude mesRes = new ResourceInclude(new Uri(mesResource)) { 
                Source = new Uri(mesResource)
            };
            ResourceInclude labelRes = new ResourceInclude(new Uri(labelResource)) { 
                Source = new Uri(labelResource)
            };
            Application.Current.Resources.MergedDictionaries.RemoveAt(mesPos);
            Application.Current.Resources.MergedDictionaries.Insert(mesPos, mesRes);
            Application.Current.Resources.MergedDictionaries.RemoveAt(labelPos);
            Application.Current.Resources.MergedDictionaries.Insert(labelPos, labelRes);
        }

        private static string GetMessageResource(Languages lang)
        {
            switch (lang)
            {
                case Languages.English_US:
                    return "avares://SchoolManagement.UI/Languages/Message-us.axaml";

                default:
                    return "avares://SchoolManagement.UI/Languages/Message-vn.axaml";
            }
        }
        private static string GetLabelResource(Languages lang)
        {
            switch (lang)
            {
                case Languages.English_US:
                    return "avares://SchoolManagement.UI/Languages/Label-us.axaml";

                default:
                    return "avares://SchoolManagement.UI/Languages/Label-vn.axaml";
            }
        }
    }
}