using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    public class SemesterAverageViewModel : BaseRegionViewModel
    {
        public override string Title => "Trung bình học kỳ";

        public override User User { get; protected set; }

        public SemesterAverageViewModel()
        {
            User = RootContext.CurrentUser;
        }

        public Student Student { get; set; }

    }
}