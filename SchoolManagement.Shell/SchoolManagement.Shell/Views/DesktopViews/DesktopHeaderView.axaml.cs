using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views.DesktopViews;

public partial class DesktopHeaderView : UserControl
{
    private CommonMenuViewModel _menuViewModel;

    public DesktopHeaderView()
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