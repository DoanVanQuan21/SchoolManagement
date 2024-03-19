using Avalonia.Controls;
using Prism.Mvvm;

namespace SchoolManagement.Core.Models.Common
{
    public class AppRegion : BindableBase
    {
        private UserControl? mainRegion;
        private UserControl regionPage;

        public UserControl? MainRegion
        { get => mainRegion; set { SetProperty(ref mainRegion, value); } }

        public UserControl RegionPage { get => regionPage; set { SetProperty(ref regionPage,value); } }
        public AppRegion()
        {
            MainRegion = new UserControl();
        }
    }
}