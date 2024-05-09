using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.GradeSheetManagement.ViewModels;

namespace SchoolManagement.GradeSheetManagement.Views
{
    public partial class SemesterAverageView : UserControl
    {
        public SemesterAverageView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<SemesterAverageViewModel>();
        }
    }
}
