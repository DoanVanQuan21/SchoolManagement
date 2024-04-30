using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.GradeSheetManagement.ViewModels;

namespace SchoolManagement.GradeSheetManagement.Views.Dialogs
{
    public partial class UploadGradeSheets : UserControl
    {
        public UploadGradeSheetViewModel GradeSheetViewModel { get; set; }

        public UploadGradeSheets()
        {
            InitializeComponent();
            GradeSheetViewModel = Ioc.Resolve<UploadGradeSheetViewModel>();
            DataContext = GradeSheetViewModel;
            var container = this.FindControl<DataGrid>("Container");
            container.LoadingRow += Container_LoadingRow;
        }

        private void Container_LoadingRow(object? sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
