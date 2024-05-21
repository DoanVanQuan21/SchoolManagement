using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views.MobileViews
{
    public partial class SettingView : UserControl
    {
        private CommonMenuViewModel _menuViewModel;

        public SettingView()
        {
            InitializeComponent();
            _menuViewModel = Ioc.Resolve<CommonMenuViewModel>();
            DataContext = _menuViewModel;
        }

        private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            _menuViewModel.ChangeLanguageCommand.Execute(null);
        }
    }
}