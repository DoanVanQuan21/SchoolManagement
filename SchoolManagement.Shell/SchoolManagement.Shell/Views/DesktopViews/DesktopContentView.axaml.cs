using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;
using System.Linq;

namespace SchoolManagement.Shell.Views.DesktopViews
{
    public partial class DesktopContentView : UserControl
    {
        private readonly MainContentViewModel viewModel;

        public DesktopContentView()
        {
            InitializeComponent();
            viewModel = Ioc.Resolve<MainContentViewModel>();
            DataContext = viewModel;
        }

        private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            viewModel.ClickSelectionPageCommand.Execute(e.AddedItems[0]);
        }
    }
}