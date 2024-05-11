using Avalonia.Controls;
using SchoolManagement.ClassManagement.ViewModels;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.ClassManagement.Views.Dialogs
{
    public partial class AddClassView : UserControl
    {
        public AddClassViewModel ViewModel { get; set; }
        public AddClassView()
        {
            InitializeComponent();
            ViewModel = Ioc.Resolve<AddClassViewModel>();
            DataContext = ViewModel;
        }
        public void SetAddClassAction(Action<Class> action)
        {
            ViewModel.AddClass = action;
        }
    }
}
