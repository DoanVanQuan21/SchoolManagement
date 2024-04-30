using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.GradeSheetManagement.ViewModels;

namespace SchoolManagement.GradeSheetManagement.Views
{
    public partial class GradeSheetManagementView : UserControl
    {
        public GradeSheetManagementView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<GradeSheetManagementViewModel>();
            Container.LoadingRow += Container_LoadingRow;
        }

        private void Container_LoadingRow(object? sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}