using Avalonia.Controls;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.GradeSheetManagement.ViewModels;

namespace SchoolManagement.GradeSheetManagement.Views.Dialogs
{
    public partial class RequestEditGradeSheetView : UserControl
    {
        public RequestEditGradeSheetViewModel ViewModel { get; set; }

        public RequestEditGradeSheetView()
        {
            InitializeComponent();
            ViewModel = Ioc.Resolve<RequestEditGradeSheetViewModel>();
            DataContext = ViewModel;
        }

        public void SetSendRequestEvent(Action<EditGradeSheetForm> action)
        {
            ViewModel.SendRequest = action;
        }
    }
}