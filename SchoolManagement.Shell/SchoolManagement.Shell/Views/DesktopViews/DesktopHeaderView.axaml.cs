using Avalonia.Controls;
using Prism.Events;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Managers;
using SchoolManagement.Core.Models;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Shell.ViewModels;
using System;

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