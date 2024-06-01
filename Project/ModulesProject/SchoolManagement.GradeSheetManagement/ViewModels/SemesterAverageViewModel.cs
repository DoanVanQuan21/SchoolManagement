using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    public class SemesterAverageViewModel : BaseRegionViewModel
    {
        private const int DEFAULT_NUMBER_SEMESTER = 2;
        private const double MIN_GOOD_SCORE = 5.0;
        private const double MIN_EXCELLENT_SCORE = 8.0;
        private const double MIN_ALL_GRADESHEET_EXCELLENT_SCORE = 6.5;
        private const int NUMBER_OF_RANKED = 4;
        private Date currentDate;
        private SemesterAverage semesterAverage;

        public override string Title => Util.GetResourseString("ViewFinalGrades_Label");

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
                NotificationManager.ShowWarning(Util.GetResourseString("DatabaseFailed_Message"));
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
                    var ranked = Ranked.Excellent;
                    var semesterAvers = new List<double>();
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
                        var semesAver = (double)grade.SemesterAverage;
                        count++;
                        totalGrade += semesAver;
                        semesterAvers.Add(semesAver);
                    }
                    if (count <= 8)
                    {
                        SetDefaultSemesterAverage(sem);
                        continue;
                    }
                    var semesterAver = Math.Round(totalGrade / count, 2);
                    if (IsExcellentRanked(semesterAvers, semesterAver))
                    {
                        SetSemester(Ranked.Excellent, count, semesterAver, sem);
                        countSemester++;
                        continue;
                    }
                    if (IsGoodRanked(semesterAvers, semesterAver))
                    {
                        SetSemester(Ranked.Good, count, semesterAver, sem);
                        countSemester++;
                        continue;
                    }
                    if (IsAverageRanked(semesterAvers, semesterAver))
                    {
                        SetSemester(Ranked.Average, count, semesterAver, sem);
                        countSemester++;
                        continue;
                    }
                    SetSemester(Ranked.BelowAverage, count, semesterAver, sem);
                    countSemester++;
                    continue;
                }
            });
        }

        private void SetSemester(string rank, int totalSubject, double average, SemesterAverage sem)
        {
            sem.TotalSubject = totalSubject;
            sem.Rank = rank;
            sem.Average = average;
        }

        private bool IsGoodRanked(List<double> semesterAvers,double semes)
        {
            if (semes < 6.5)
            {
                return false;
            }
            var isAboveFive = semesterAvers.Any(s => s < 5.0);
            if (isAboveFive)
            {
                return false;
            }
            var aboveSixPointFives = semesterAvers.Where(s => s >= 6.5);
            if (aboveSixPointFives?.Any() == false)
            {
                return false;
            }
            if (aboveSixPointFives?.Count() < 6)
            {
                return false;
            }
            return true;
        }

        private bool IsExcellentRanked(List<double> semesterAvers, double semes)
        {
            if (semes < 8.0)
            {
                return false;
            }
            var isAboveSixPointFives = semesterAvers.Any(s => s < 6.5);
            if (isAboveSixPointFives)
            {
                return false;
            }
            var aboveEights = semesterAvers.Where(s => s >= 8);
            if (aboveEights?.Any() == false)
            {
                return false;
            }
            if (aboveEights?.Count() < 6)
            {
                return false;
            }
            return true;
        }

        private bool IsAverageRanked(List<double> semesterAvers,double semes)
        {
            if (semes < 5.0)
            {
                return false;
            }
            var isAboveThreePointFive = semesterAvers.Any(s => s < 3.5);
            if (isAboveThreePointFive)
            {
                return false;
            }
            var aboveEights = semesterAvers.Where(s => s >= 5);
            if (aboveEights?.Any() == false)
            {
                return false;
            }
            if (aboveEights?.Count() < 6)
            {
                return false;
            }
            return true;
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