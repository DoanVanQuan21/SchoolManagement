using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.GradeSheetManagement.ViewModels;

namespace SchoolManagement.GradeSheetManagement.Views
{
    public partial class ComponentGradeSheetView : UserControl
    {
        public ComponentGradeSheetView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<ComponentGradeSheetViewModel>();
        }
    }
}