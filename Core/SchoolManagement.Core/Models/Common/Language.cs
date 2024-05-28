using Prism.Mvvm;
using SchoolManagement.Core.Constants;

namespace SchoolManagement.Core.Models.Common
{
    public class Language : BindableBase
    {
        private string languageName;
        private Languages languageType;

        public string LanguageName { get => languageName; set => SetProperty(ref languageName, value); }
        public Languages LanguageType { get => languageType; set => SetProperty(ref languageType, value); }

        public Language()
        {
        }

        public Language(Language lang)
        {
            LanguageName = lang.languageName;
            LanguageType = lang.languageType;
        }
    }
}