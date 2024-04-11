using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views
{
    public partial class MainDesktopView : Window
    {
        private MainViewModel viewModel;
        private readonly IAppManager _appManager;

        public MainDesktopView()
        {
            InitializeComponent();
            _appManager = Ioc.Resolve<IAppManager>();
            viewModel = Ioc.Resolve<MainViewModel>();
            DataContext = viewModel;
        }

        private void Window_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            viewModel.NotificationManager.InitNotification(this, NotificationPosition.BottomRight, 1);
        }

        private void Window_Closing(object? sender, Avalonia.Controls.WindowClosingEventArgs e)
        {
            _appManager.Save();
        }
    }
}