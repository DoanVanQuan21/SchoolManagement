using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Views.MobileViews
{
    public partial class MobileContentView : UserControl
    {
        private MainContentViewModel viewModel;
        public MobileContentView()
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