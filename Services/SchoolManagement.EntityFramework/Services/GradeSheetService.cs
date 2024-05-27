using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class GradeSheetService : BaseService, IGradeSheetService
    {
        private readonly ICourseService _courseService;
        private readonly IClassService _classService;
        private readonly IStudentService _studentService;

        public GradeSheetService() : base()
        {
            _courseService = Ioc.Resolve<ICourseService>();
            _studentService = Ioc.Resolve<IStudentService>();
            _classService = Ioc.Resolve<IClassService>();
        }

        public async Task<ObservableCollection<GradeSheet>> FinishEditGradeSheet(ObservableCollection<GradeSheet> gradeSheets)
        {
            return await _schoolManagementSevice.GradeSheetRepository.FinishEditGradeSheet(gradeSheets);
        }

        public async Task<ObservableCollection<GradeSheet>> GetGradeSheetsByStudentID(int studentID)
        {
            return await _schoolManagementSevice.GradeSheetRepository.GetGradeSheetsByStudentID(studentID);
        }

        public async Task<ObservableCollection<GradeSheet>> GetGradeSheetsByStudentID(int studentID, int year)
        {
            var gradeSheets = await _schoolManagementSevice.GradeSheetRepository.GetGradeSheetsByStudentID(studentID);
            if (gradeSheets == null)
            {
                return new();
            }
            var gradesInYear = new ObservableCollection<GradeSheet>();

            foreach (var gradeSheet in gradeSheets)
            {
                var course = await _courseService.GetCourseByID(gradeSheet.CourseId);
                if (course == null)
                {
                    continue;
                }
                if (course.StartDate.Year != year)
                {
                    continue;
                }
                gradeSheet.Course = course;
                gradesInYear.Add(gradeSheet);
            }
            foreach (var grade in gradesInYear)
            {
                grade.Ranked = GradeSheet.GetRanked(grade);
                grade.Student = await _studentService.GetStudentByStudentID(grade.StudentId);
                await Task.Delay(10);
            }
            return gradesInYear;
        }

        public async Task<GradeSheet?> GetGradeSheet(int gradeSheetID)
        {
            var grade = _schoolManagementSevice.GradeSheetRepository.FirstOrDefault(g => g.GradeSheetId == gradeSheetID);
            if (grade == null)
            {
                return grade;
            }
            var course = await _courseService.GetCourseByID(grade.CourseId);
            if (course == null)
            {
                return grade;
            }
            grade.Course = course;
            return grade;
        }

        public async Task<bool> UpdateGradeSheetAsync(GradeSheet gradeSheet)
        {
            return await _schoolManagementSevice.GradeSheetRepository.Update(gradeSheet);
        }

        public async Task<ObservableCollection<GradeSheet>> GetGradeSheetOfSubjectByClass(int courseID)
        {
            var grades = await _schoolManagementSevice.GradeSheetRepository.GetGradeSheetOfSubjectByClass(courseID);
            if (grades == null)
            {
                return new();
            }
            foreach (var grade in grades)
            {
                grade.Ranked = GradeSheet.GetRanked(grade);
                grade.Course = await _courseService.GetCourseByID(grade.CourseId);
                grade.Student = await _studentService.GetStudentByStudentID(grade.StudentId);
            }
            return grades;
        }

        public async Task<bool> UnLock(int gradeSheetID)
        {
            return await _schoolManagementSevice.GradeSheetRepository.UnLock(gradeSheetID);
        }

        public async Task<bool> UpdateOrAddRange(ObservableCollection<GradeSheet> gradeSheets)
        {
            return await _schoolManagementSevice.GradeSheetRepository.UpdateOrAddRange(gradeSheets);
        }

        public Task<bool> AddGradeSheet(GradeSheet gradeSheet)
        {
            return Task.Factory.StartNew(() => {
                if (gradeSheet == null)
                {
                    return false;
                }
                gradeSheet.Lock = false;
                gradeSheet.PromotionDecision = true;
                _schoolManagementSevice.GradeSheetRepository.Add(gradeSheet);
                return true;
            });
        }
    }
}