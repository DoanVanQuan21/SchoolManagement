using Avalonia;
using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views
{
    public partial class MainMobileView : UserControl
    {
        private MainViewModel viewModel;

        public MainMobileView()
        {
            InitializeComponent();
            viewModel = Ioc.Resolve<MainViewModel>();
            DataContext = viewModel;
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            viewModel.NotificationManager.InitNotification(this, Avalonia.Controls.Notifications.NotificationPosition.TopRight, 1);
            base.OnAttachedToVisualTree(e);
        }
    }
}