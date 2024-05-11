using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.StudentManagement.ViewModels;

namespace SchoolManagement.StudentManagement.Views
{
    public partial class StudentManagementView : UserControl
    {
        public StudentManagementView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<StudentManagementViewModel>();
            Container.LoadingRow += Container_LoadingRow;
        }

        private void Container_LoadingRow(object? sender, DataGridRowEventArgs e)
        {
            e.Row.Header = $"{e.Row.GetIndex() + 1}";
        }
    }
}
