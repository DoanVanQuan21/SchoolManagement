using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.GradeSheetManagement.ViewModels;

namespace SchoolManagement.GradeSheetManagement.Views.Dialogs
{
    public partial class EditGradeSheetView : UserControl
    {
        public EditGradeSheetViewModel ViewModel { get; set; }
        public EditGradeSheetView()
        {
            InitializeComponent();
            ViewModel  = Ioc.Resolve<EditGradeSheetViewModel>();
            DataContext = ViewModel ;
        }
    }
}
