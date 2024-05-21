using Avalonia.Controls;
using Prism.Events;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Managers;
using SchoolManagement.Core.Models;
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

    private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        var value = e.AddedItems[0].ToString();
        var lang = Enum.Parse<Languages>(value);
        UpdateLanguage(lang);
    }

    private void UpdateLanguage(Languages lang)
    {
        var isChanged = LanguageHelper.ChangeLanguage(lang);
        if (!isChanged)
        {
            _notificationManager.ShowWarning(Util.GetResourseString("ChangeLanguageError_Message"));
            return;
        }
        _notificationManager.ShowSuccess(Util.GetResourseString("ChangeLanguageSuccess_Message"));
        _appManager.BootSetting.CurrentLanguage = lang;
        Ioc.Resolve<IEventAggregator>().GetEvent<ChangeLangEvent>().Publish();
        return;
    }
}