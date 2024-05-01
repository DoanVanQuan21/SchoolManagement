using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using SchoolManagement.EntityFramework.Services;
using System.Collections.ObjectModel;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    public class ComponentGradeSheetViewModel : BaseRegionViewModel
    {
        private readonly IStudentService _studentService;
        private readonly IGradeSheetService _gradeSheetService;
        public override string Title => "Điểm thành phần";

        public override User User { get; protected set; }

        public ComponentGradeSheetViewModel()
        {
            _studentService = Ioc.Resolve<IStudentService>();
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            User = RootContext.CurrentUser;
            GradeSheets = new();
            GetGradeSheets();
        }

        public ObservableCollection<GradeSheet> GradeSheets { get; set; }

        private async void GetGradeSheets()
        {
            GradeSheets.Clear();
            var student = await _studentService.GetStudentByUserID(User.UserId);
            var grades = await _gradeSheetService.GetAllGradeSheetByClassAndStudentID(student.StudentId, student.ClassId);
            if (grades == null)
            {
                NotificationManager.ShowWarning("Không có bảng điểm nào!.");
                return;
            }
            GradeSheets.AddRange(grades);
        }
    }
}