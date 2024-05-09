using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    public class SemesterAverageViewModel : BaseRegionViewModel
    {
        private const int DEFAULT_NUMBER_SEMESTER = 2;
        private Date currentDate;
        private SemesterAverage semesterAverage;

        public override string Title => "Trung bình học kỳ";

        public override User User { get; protected set; }
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public SemesterAverageViewModel()
        {
            _courseService = Ioc.Resolve<ICourseService>();
            _studentService = Ioc.Resolve<IStudentService>();
            User = RootContext.CurrentUser;
            SemesterAverages = new();
            InitSemeseters();
        }

        private async void InitSemeseters()
        {
            SemesterAverages.Clear();
            SemesterAverages.AddRange(SemesterAverage.SemesterAverages);
            await InitDates();
        }

        private async Task InitDates()
        {
            Dates = new();
            var startYear = User.StartDate.Year;
            var now = DateTime.Now.Year;
            for (int i = startYear; i <= now; i++)
            {
                Dates.Add(new Date()
                {
                    Year = i,
                });
                await Task.Delay(100);
            }
            CurrentDate = Dates.LastOrDefault();
        }

        public Student Student { get; set; }
        public ObservableCollection<SemesterAverage> SemesterAverages { get; set; }
        public ObservableCollection<Date> Dates { get; set; }

        public Date CurrentDate
        { get => currentDate; set { SetProperty(ref currentDate, value); GetSummaryGradeSheet(); } }

        public SemesterAverage SemesterAverage
        { get => semesterAverage; set { SetProperty(ref semesterAverage, value); } }

        private async void GetSummaryGradeSheet()
        {
            var student = await _studentService.GetStudentAndGradeSheets(User.UserId);
            if (student == null)
            {
                NotificationManager.ShowWarning("Có lỗi xảy ra, hãy kiểm tra lại thông tin!.");
                return;
            }
            if (student.GradeSheets?.Any() == false)
            {
                return;
            }
            await SetCourse(student);
            await SetSemester(student);
        }

        private Task SetSemester(Student student)
        {
            return Task.Factory.StartNew(() =>
            {
                int countSemester = 0;
                foreach (var sem in SemesterAverages)
                {
                    if (countSemester == DEFAULT_NUMBER_SEMESTER)
                    {
                        CalculateFinnalSchoolYear();
                        break;
                    }
                    var count = 0;
                    double totalGrade = 0;
                    foreach (var grade in student.GradeSheets)
                    {
                        if (grade.Course == null)
                        {
                            continue;
                        }
                        if (grade.Course.StartDate.Year != CurrentDate.Year || sem.Semester != grade.Course.Semester || grade.SemesterAverage == null)
                        {
                            continue;
                        }
                        count++;
                        totalGrade += (double)grade.SemesterAverage;
                    }
                    if (count <= 0)
                    {
                        SetDefaultSemesterAverage(sem);
                        continue;
                    }
                    sem.TotalSubject = count;
                    sem.Average = totalGrade / count;
                    countSemester++;
                }
            });
        }

        private void CalculateFinnalSchoolYear()
        {
            var finnalSemester = SemesterAverages.LastOrDefault();
            var missingSemester = SemesterAverages.FirstOrDefault(s => string.IsNullOrEmpty(s.Rank));
            if (missingSemester == null)
            {
                SetDefaultSemesterAverage(finnalSemester);
                return;
            }
            finnalSemester.TotalSubject = SemesterAverages.First().TotalSubject + SemesterAverages[1].TotalSubject;
            finnalSemester.Average = (SemesterAverages.First().Average + SemesterAverages[1].Average) / 2;
        }

        private void SetDefaultSemesterAverage(SemesterAverage semester)
        {
            semester.TotalSubject = 0;
            semester.Average = 0;
            semester.Rank = "";
        }

        private async Task SetCourse(Student student)
        {
            foreach (var grade in student.GradeSheets)
            {
                grade.Course = await _courseService.GetCourseByID(grade.CourseId);
            }
        }
    }
}