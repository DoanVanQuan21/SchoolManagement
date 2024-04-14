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
        }
    }
}