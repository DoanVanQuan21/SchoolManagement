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
    private readonly INotificationManager _notificationManager;
    private readonly IAppManager _appManager;

    public DesktopHeaderView()
    {
        InitializeComponent();
        _appManager = Ioc.Resolve<IAppManager>();
        _notificationManager = Ioc.Resolve<INotificationManager>();
        DataContext = Ioc.Resolve<CommonMenuViewModel>();
    }
}