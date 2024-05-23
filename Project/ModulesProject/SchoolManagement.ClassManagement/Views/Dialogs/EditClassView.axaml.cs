using Avalonia.Controls;
using SchoolManagement.ClassManagement.ViewModels;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.ClassManagement.Views.Dialogs
{
    public partial class EditClassView : UserControl
    {
        public EditClassViewModel ViewModel { get; set; }
        public EditClassView()
        {
            InitializeComponent();
            ViewModel = Ioc.Resolve<EditClassViewModel>();
            DataContext = ViewModel;
        }
        public void SetEditClassAction(Action<Class> action)
        {
            ViewModel.EditClass = action;
        }
    }
}
