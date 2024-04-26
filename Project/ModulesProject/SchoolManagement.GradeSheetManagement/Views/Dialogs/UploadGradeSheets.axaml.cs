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
        }
    }
}
