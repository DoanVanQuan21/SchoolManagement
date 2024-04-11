using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views
{
    public partial class MainDesktopView : Window
    {
        private MainViewModel viewModel;

        public MainDesktopView()
        {
            InitializeComponent();
            viewModel = Ioc.Resolve<MainViewModel>();
            DataContext = viewModel;
        }

        private void Window_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            viewModel.NotificationManager.InitNotification(this, NotificationPosition.TopRight, 1);
        }
    }
}