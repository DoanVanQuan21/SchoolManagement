using Avalonia;
using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views
{
    public partial class MainMobileView : UserControl
    {
        private MainViewModel viewModel;
        private readonly IAppManager _appManager;

        public MainMobileView()
        {
            InitializeComponent();
            _appManager = Ioc.Resolve<IAppManager>();
            viewModel = Ioc.Resolve<MainViewModel>();
            DataContext = viewModel;
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            viewModel.NotificationManager.InitNotification(this, Avalonia.Controls.Notifications.NotificationPosition.TopLeft, 1);
            base.OnAttachedToVisualTree(e);
        }

        private void UserControl_Unloaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _appManager.Save();
        }
    }
}