using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.CourseManagement.ViewModels;

namespace SchoolManagement.CourseManagement.Views
{
    public partial class CourseManagementView : UserControl
    {
        public CourseManagementView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<CourseManagementViewModel>();
            Container.LoadingRow += Container_LoadingRow;
        }

        private void Container_LoadingRow(object? sender, DataGridRowEventArgs e)
        {
            e.Row.Header = $"{e.Row.GetIndex() + 1}";
        }
    }
}