using Avalonia.Controls;
using SchoolManagement.ClassManagement.ViewModels;
using SchoolManagement.Core.avalonia;

namespace SchoolManagement.ClassManagement.Views.Dialogs
{
    public partial class ConfirmDeleteClassView : UserControl
    {
        private ConfirmDeleteClassViewModel ViewModel { get; set; }

        public ConfirmDeleteClassView()
        {
            InitializeComponent();
            ViewModel = Ioc.Resolve<ConfirmDeleteClassViewModel>();
            DataContext = ViewModel;
        }

        public void SetOnOkClicked(Action action)
        {
            ViewModel.OnOK = action;
        }
    }
}