using Avalonia.Controls;
using Prism.Mvvm;

namespace SchoolManagement.Core.Models.Common
{
    public class AppRegion : BindableBase
    {
        private UserControl? mainRegion;
        private UserControl regionPage;

        public UserControl? MainView
        { get => mainRegion; set { SetProperty(ref mainRegion, value); } }

        public UserControl MainPage { get => regionPage; set { SetProperty(ref regionPage,value); } }
        public AppRegion()
        {
        }
    }
}