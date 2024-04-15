using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.GradeSheetManagement.ViewModels;

namespace SchoolManagement.GradeSheetManagement.Views
{
    public partial class EditGradeSheetView : UserControl
    {
        public EditGradeSheetView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<EditGradeSheetViewModel>();
        }
    }
}
