using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class GradeSheetRepository : GenerateRepository<GradeSheet>, IGradeSheetRepository<GradeSheet>
    {
        private readonly ObservableCollection<GradeSheet> _grades;

        public GradeSheetRepository(SchoolManagementContext context) : base(context)
        {
            _grades = new();
        }

        public Task<ObservableCollection<GradeSheet>> FinishEditGradeSheet(ObservableCollection<GradeSheet> gradeSheets)
        {
            return Task.Factory.StartNew(() =>
            {
                var missingGrades = new ObservableCollection<GradeSheet>();
                var gradeSheetsNotLock = Where(g => g.Lock == false);
                if (gradeSheetsNotLock?.Any() == false)
                {
                    return missingGrades;
                }
                foreach (var gradeSheet in gradeSheets)
                {
                    var isLocked = LockGradeSheet(gradeSheet);
                    if (isLocked != false)
                    {
                        continue;
                    }
                    missingGrades.Add(gradeSheet);
                }
                return missingGrades;
            });
        }

        public Task<ObservableCollection<GradeSheet>> GetGradeSheetOfSubjectByClass(int courseID)
        {
            return Task.Factory.StartNew(() =>
            {
                _grades.Clear();
                var grades = Where(g => g.CourseId == courseID);
                if (grades?.Any() == false)
                {
                    return _grades;
                }
                _grades.AddRange(grades);
                return _grades;
            });
        }

        public Task<ObservableCollection<GradeSheet>> GetGradeSheetsByStudentID(int studentID)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    if (_context.GradeSheets.Any() == false)
                    {
                        return _grades;
                    }
                    _grades.Clear();
                    var grades = _context.GradeSheets.Where(g => g.StudentId == studentID);
                    if (grades == null)
                    {
                        return _grades;
                    }
                    _grades.AddRange(grades);
                    return _grades;
                }
                catch (Exception)
                {
                    return _grades;
                }
            });
        }

        public Task<bool> UnLock(int gradeSheetID)
        {
            return Task.Factory.StartNew(() =>
            {
                var grade = FirstOrDefault(g => g.GradeSheetId == gradeSheetID);
                if (grade == null)
                {
                    return false;
                }
                grade.Lock = false;
                _context.SaveChanges();
                return true;
            });
        }

        public Task<bool> Update(GradeSheet entity)
        {
            return Task.Factory.StartNew(() =>
            {
                var gradeSheet = FirstOrDefault(item => item.GradeSheetId == entity.GradeSheetId);
                if (gradeSheet == null)
                {
                    return false;
                }
                gradeSheet.FirstRegularScore = entity.FirstRegularScore;
                gradeSheet.SecondRegularScore = entity.SecondRegularScore;
                gradeSheet.ThirdRegularScore = entity.ThirdRegularScore;
                gradeSheet.FourRegularScore = entity.FourRegularScore;
                gradeSheet.MidtermScore = entity.MidtermScore;
                gradeSheet.FinalScore = entity.FinalScore;
                gradeSheet.SemesterAverage = ComputeSemesterAverage(gradeSheet);
                _context.SaveChanges();
                return true;
            });
        }
        public Task<bool> UpdateOrAddRange(ObservableCollection<GradeSheet> gradeSheets)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    foreach (var grade in gradeSheets)
                    {
                        var gs = FirstOrDefault(g => g.CourseId == grade.CourseId && g.StudentId == grade.StudentId);
                        if (gs == null)
                        {
                            Add(grade);
                            Task.Delay(100);
                            continue;
                        }
                        UpdateByClassIDAndSubjectID(gs,grade);
                        Task.Delay(100);
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
        public Task<bool> UpdateByClassIDAndSubjectID(GradeSheet gradeSheet,GradeSheet newGrade)
        {
            return Task.Factory.StartNew(() =>
            {
                gradeSheet.FirstRegularScore = newGrade.FirstRegularScore;
                gradeSheet.SecondRegularScore = newGrade.SecondRegularScore;
                gradeSheet.ThirdRegularScore = newGrade.ThirdRegularScore;
                gradeSheet.FourRegularScore = newGrade.FourRegularScore;
                gradeSheet.MidtermScore = newGrade.MidtermScore;
                gradeSheet.FinalScore = newGrade.FinalScore;
                gradeSheet.SemesterAverage = ComputeSemesterAverage(gradeSheet);
                _context.SaveChanges();
                return true;
            });
        }
        private double? ComputeSemesterAverage(GradeSheet gradeSheet)
        {
            return (gradeSheet.FirstRegularScore + gradeSheet.SecondRegularScore + gradeSheet.ThirdRegularScore
            + gradeSheet.FourRegularScore + gradeSheet.MidtermScore * 2 + gradeSheet.FinalScore * 3) / 9;
        }
        private bool LockGradeSheet(GradeSheet grade)
        {
            var g = FirstOrDefault(g => g.GradeSheetId == grade.GradeSheetId);
            if (g == null)
            {
                return false;
            }
            g.Lock = true;
            _context.SaveChanges();
            return true;
        }
    }
}