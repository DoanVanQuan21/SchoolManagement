using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.SubjectManagement.ViewModels;

namespace SchoolManagement.SubjectManagement.Views
{
    public partial class SubjectManagementView : UserControl
    {
        public SubjectManagementView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<SubjectManagementViewModel>();
        }
    }
}
