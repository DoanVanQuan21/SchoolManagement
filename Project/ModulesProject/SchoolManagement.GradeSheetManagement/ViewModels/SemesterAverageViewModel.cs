using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    public class SemesterAverageViewModel : BaseRegionViewModel
    {
        private int totalCourseSemesterFirst;
        private int totalCourseSemesterSecond;
        private double semesterAverageSecond;
        private double semesterAverageFirst;

        public override string Title => "Trung bình học kỳ";

        public override User User { get; protected set; }

        public SemesterAverageViewModel()
        {
            User = RootContext.CurrentUser;
            SemesterAverages = new();
        }

        public Student Student { get; set; }
        public ObservableCollection<Semester> SemesterAverages { get; set; }
    }
}