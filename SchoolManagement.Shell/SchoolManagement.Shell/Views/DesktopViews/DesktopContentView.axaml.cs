using Avalonia.Controls;
using Prism.Events;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Events;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Shell.ViewModels;
using System.Diagnostics;

namespace SchoolManagement.Shell.Views.DesktopViews
{
    public partial class DesktopContentView : UserControl
    {
        private readonly MainContentViewModel viewModel;
        private AppMenu appMenu;
        public DesktopContentView()
        {
            InitializeComponent();
            viewModel = Ioc.Resolve<MainContentViewModel>();
            Ioc.Resolve<IEventAggregator>().GetEvent<RequestRefreshPageEvent>().Subscribe(OnRefresh);
            DataContext = viewModel;
        }
        private void OnRefresh()
        {
            if (appMenu == null)
            {
                return;
            }
            foreach (var menu in RootContext.DesktopAppMenus)
            {
                if (appMenu.Type == menu.Type)
                {
                    viewModel.ClickSelectionPageCommand.Execute(menu);
                    return;
                }
            }
        }
        private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                viewModel.ClickSelectionPageCommand.Execute(e.AddedItems[0]);
                appMenu = e.AddedItems[0] as AppMenu;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(e);
            }
        }
    }
}